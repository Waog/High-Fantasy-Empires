using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FollowTransform : NetworkBehaviour
{
    public float speed = 1f;

    [SyncVar]
    public Transform target;

    void Update()
    {
        // Debug.Log(gameObject.name + " may update position in the direction of:" + target.gameObject.name);
        if (isServer && target)
        {
            Vector3 direction = target.position - transform.position;
            Vector3 normalizedDirection = direction.normalized;
            Vector3 intermediateTargetDirection = Time.deltaTime * normalizedDirection * speed;
            Vector3 intermediateTargetDirectionClamped = Vector3.ClampMagnitude(intermediateTargetDirection, direction.magnitude);
            transform.position += intermediateTargetDirectionClamped;
            // Debug.Log(gameObject.name + " updates position in the direction of:" + target.gameObject.name);
        }
    }
}
