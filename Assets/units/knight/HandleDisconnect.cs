using UnityEngine;
using UnityEngine.Networking;

public class HandleDisconnect : NetworkBehaviour
{
    private void Update()
    {
        if (isServer && !GetComponent<FollowTransform>().target)
        {
            Destroy(gameObject);
        }
    }
}