using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HitKnight : NetworkBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isServer && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().takeHit();
        }
    }
}
