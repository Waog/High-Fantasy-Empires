using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SelectTarget : NetworkBehaviour
{

    void Update()
    {
        if (isServer)
        {

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            float closestDistance = float.MaxValue;
            Transform closestPlayer = null;

            foreach (GameObject player in players)
            {
                float curDistance = (player.transform.position - transform.position).magnitude;
                if (curDistance < closestDistance)
                {
                    closestDistance = curDistance;
                    closestPlayer = player.transform;
                }
            }

            GetComponent<FollowTransform>().target = closestPlayer;
        }
    }
}
