using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnKnight : NetworkBehaviour
{
    public GameObject knightPrefab;

    public override void OnStartServer()
    {
        GameObject knight = (GameObject)Instantiate(knightPrefab);
        NetworkServer.Spawn(knight);

        knight.transform.position = transform.position;
        knight.GetComponent<FollowTransform>().target = transform;
        Color tint = getRandomTint();
        knight.GetComponent<SpriteRenderer>().color = tint;
        gameObject.GetComponent<SpriteRenderer>().color = tint;

    }

    private Color getRandomTint()
    {
        return Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
    }
}
