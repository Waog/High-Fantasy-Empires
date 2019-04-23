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
                Inventory yield = collision.gameObject.GetComponent<Inventory>();
                GetComponent<Inventory>().add(yield);
                Destroy(collision.gameObject);
            }
        }
    }
}
