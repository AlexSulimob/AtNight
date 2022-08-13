using UnityEngine;
using Zenject;

public class CrossBehaviour : MonoBehaviour {

    [Inject]
    InputService inputService;
    public SpriteRenderer sprite;

    void Start() {
        Cursor.visible = false;
    }
    void FixedUpdate() {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(inputService.MOUSE_POS);
        transform.position = mouseCursorPos;

        if (!inputService.isGameplayInputsOn)
        {
            sprite.enabled = false;
        }
        else 
        {
            sprite.enabled = true;
        }
    }

}
