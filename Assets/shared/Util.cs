using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Util
{
    public static Transform getLocalPlayer()
    {
        GameObject[] allKnights = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject knight in allKnights)
        {
            Transform targetIndicator = knight.GetComponent<FollowTransform>().target;
            if (targetIndicator.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                return targetIndicator;
            }
        }
        return null;
    }
}
