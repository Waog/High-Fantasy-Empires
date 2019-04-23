using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PrefabGenerator : NetworkBehaviour
{

    public GameObject prefab;
    public int initialAmount;
    public GameObject area;

    void Start()
    {
        if (isServer)
        {
            for (int i = 0; i < initialAmount; i++)
            {
                GameObject obj = (GameObject)Instantiate(prefab);
                obj.transform.SetParent(transform);
                NetworkServer.Spawn(obj);

                // NetworkServer.Spawn(new GameObject("TreeContainer"));

                float x = Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
                float y = Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
                int roundedX = Mathf.RoundToInt(x);
                int roundedY = Mathf.RoundToInt(y);
                obj.transform.position = new Vector3(roundedX, roundedY, 0);
            }
        }
    }
}
