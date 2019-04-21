using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FollowObject : FollowTransform
{

    [SyncVar]
    public GameObject targetObj;

    void Update()
    {
        if (targetObj)
        {
            target = targetObj.transform;

        }
    }
}
