using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HandleButtonClick : MonoBehaviour
{

    public void onTestClick()
    {
        GameObject[] allKnights = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject knight in allKnights)
        {
            Transform targetIndicator = knight.GetComponent<FollowTransform>().target;
            if (targetIndicator.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                // targetIndicator.GetComponent<BuildWalls>().CmdBuildWall(new Vector3(0, 0, 0));
                // targetIndicator.GetComponent<BuildWalls>().CmdBuildWall(new Vector3(1, 0, 0));
            }
        }
    }
}
