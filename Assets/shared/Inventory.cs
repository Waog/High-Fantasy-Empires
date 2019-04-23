using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class Inventory : NetworkBehaviour
{
    [SyncVar]
    public int wood;

    [SyncVar]
    public int gems;

    internal void add(Inventory yield)
    {
        wood += yield.wood;
        gems += yield.gems;
    }

    internal bool contains(Inventory price)
    {
        return
        wood >= price.wood
        && gems >= price.gems;
    }

    internal void sub(Inventory price)
    {
        wood -= price.wood;
        gems -= price.gems;
    }
}
