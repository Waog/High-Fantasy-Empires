using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CollectColletables : NetworkBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isServer)
        {
            if (collision.gameObject.tag == "Collectable")
            {
                GetComponent<Inventory>().wood += 4;
                Destroy(collision.gameObject);
            }
        }
    }
}
