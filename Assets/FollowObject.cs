using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

// TODO: delete?
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
