using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AttachInventory : NetworkBehaviour
{
    void Update()
    {
        Transform followingTransform = gameObject.GetComponent<FollowTransform>().target;
        if (followingTransform)
        {
            GameObject targetIndicator = followingTransform.gameObject;
            if (targetIndicator.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                GameObject canvas = GameObject.Find("Canvas");
                UpdateInventoryUI[] updateScripts = canvas.GetComponentsInChildren<UpdateInventoryUI>();
                EnableBuild[] enableScripts = canvas.GetComponentsInChildren<EnableBuild>();

                foreach (var script in updateScripts)
                {
                    script.inventory = GetComponent<Inventory>();
                }

                foreach (var script in enableScripts)
                {
                    script.inventory = GetComponent<Inventory>();
                }
            }
        }
    }
}
