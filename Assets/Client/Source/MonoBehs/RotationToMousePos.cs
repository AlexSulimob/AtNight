using UnityEngine;
using Zenject;

/// <summary>
/// rotate object to mouse pos on screen with lerp speed 
/// </summary>
// TODO: get rid of addiction from Input mousePos, it wont work with gamepads
public class RotationToMousePos : MonoBehaviour
{
    [Inject]
    InputService inputService;

    public float lerpSpeed = 8f;

    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputService.MOUSE_POS);

        Vector2 direction = worldPosition - transform.position;
        direction = direction.normalized;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, lerpSpeed * Time.deltaTime);

    }
}

