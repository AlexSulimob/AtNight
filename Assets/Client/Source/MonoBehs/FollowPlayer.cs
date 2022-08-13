using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FollowPlayer : MonoBehaviour
{
    [Inject] PlayerUnit playerUnit;
    public bool onlyX;
    private void Update() {
        if(onlyX)
        {
            transform.position = new Vector2(playerUnit.transform.position.x , transform.position.y);
        }
        else
        {
            transform.position = playerUnit.transform.position;
        }
    }
}
