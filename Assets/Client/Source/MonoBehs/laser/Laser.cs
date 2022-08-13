using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Calculate ray points
/// </summary>
// TODO: get rid of addiction from Input mousePos, it wont work with gamepads
public class Laser : MonoBehaviour {

    [Inject]
    InputService inputService;

    public int reflections;
    public float lenght;

    public LineRenderer m_lineRenderer;
    public float lerpSpeed = 8f;
    Ray2D ray;

    public LayerMask mask;
    Vector2 currentDirection;

    [HideInInspector]
    public bool isFocused;

    Dictionary<Transform, LightReciver> lightReciversCached = new Dictionary<Transform, LightReciver>();

    void Update() {
        ShootLaser();
    }

    void ShootLaser() {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputService.MOUSE_POS);

        Vector2 targetDirection = worldPosition - transform.position;
        targetDirection = targetDirection.normalized;
        currentDirection =  Vector2.Lerp(currentDirection, targetDirection, lerpSpeed * Time.deltaTime);
        
        // TODO: I also need to send event on object witch globaly switch
        // light
        
        ray = new Ray2D(transform.position, currentDirection);

        m_lineRenderer.positionCount = 1;
        m_lineRenderer.SetPosition(0, transform.position);

        for (int i = 0; i < reflections; i++) {
            var hit = Physics2D.Raycast(ray.origin, ray.direction, lenght, mask);
            if (hit && hit.transform.tag == "ReflectedObject") {       //if we hit something and this object can reflect rays we reflect it
                m_lineRenderer.positionCount += 1;
                m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, hit.point);
                ray = new Ray2D(hit.point + hit.normal * 0.001f, Vector2.Reflect(ray.direction, hit.normal));
                CleanLightRecivers();          
            }
            else if (hit && hit.transform.tag == "LightSwitch" && isFocused) { //there we say to lightReciver what our rays is get throw 
                if (!lightReciversCached.ContainsKey(hit.transform)) { 
                    lightReciversCached.Add(hit.transform, hit.transform.gameObject.GetComponent<LightReciver>() );
                }
                else {
                    lightReciversCached[hit.transform].isGettingRay = true;
                }
                m_lineRenderer.positionCount += 1;
                m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, hit.point);
                break;
            }
            else if (hit && hit.transform.tag != "ReflectedObject") {   //if we hit something but its just regular object, then we stop ray 
                m_lineRenderer.positionCount += 1;
                m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, hit.point);
                CleanLightRecivers();          
                break;
            }
            else {                                                       //there we didnt hit anything and emit ray on full range in air
                m_lineRenderer.positionCount += 1;
                m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, ray.origin + ( ray.direction * lenght ));
                CleanLightRecivers();          
            }
        }
    }

    //there we set to all cached object light reciver what they
    //arent getting any rays anymore
    void CleanLightRecivers(){
        foreach (var item in lightReciversCached) {
            item.Value.isGettingRay = false;   
        }
    }
}
















