using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Inventory : NetworkBehaviour
{
    [SyncVar]
    public int wood;
}
