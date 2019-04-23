using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DieInPit : NetworkBehaviour
{

    public GameObject dropPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Pit"))
        {
            GameObject drop = (GameObject)Instantiate(dropPrefab, transform.position, Quaternion.identity);
            NetworkServer.Spawn(drop);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
