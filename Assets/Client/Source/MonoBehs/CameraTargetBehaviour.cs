using UnityEngine;
using Zenject;

public class CameraTargetBehaviour : MonoBehaviour
{
    [Inject]
    InputService inputService;

    public float speed = 2f;
    public float rangeViewMultiplier = 0.5f;
    public Transform anchor;

    public float transitionThreshold = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputService.MOUSE_POS);
        Vector2 direction = worldPosition - anchor.position;
        if (Mathf.Abs(direction.x)  > transitionThreshold
                || Mathf.Abs(direction.y)  > transitionThreshold ) {
            direction = direction.normalized;
            transform.position = Vector2.Lerp((Vector2)transform.position, (Vector2)anchor.position + (Vector2)direction * rangeViewMultiplier, speed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.Lerp((Vector2)transform.position, (Vector2)anchor.position, speed * Time.deltaTime);
        }
        
    }
}
