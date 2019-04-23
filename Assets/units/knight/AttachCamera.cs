using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AttachCamera : NetworkBehaviour
{
    void Update()
    {
        Transform followingTransform = gameObject.GetComponent<FollowTransform>().target;
        if (followingTransform)
        {
            GameObject targetIndicator = followingTransform.gameObject;
            if (targetIndicator.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                GameObject camera = GameObject.FindWithTag("MainCamera");
                camera.transform.SetParent(transform);
                camera.transform.localPosition = new Vector3(0, 0, -10);
            }
        }
    }
}
