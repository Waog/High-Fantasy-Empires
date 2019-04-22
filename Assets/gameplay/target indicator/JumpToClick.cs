using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class JumpToClick : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }

        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp(0))
        {

            Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPositionOnFloor.z = 0;
            transform.position = clickPositionOnFloor;
        }
    }
}
