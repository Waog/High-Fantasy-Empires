using UnityEngine;
using System.Collections;
using System;

public class OrderBuild : MonoBehaviour
{

    public GameObject buildingPrefab;

    internal void build()
    {
        // TODO improve code! may try to send a command directly from client-blueprint to server-blueprint
        if (buildingPrefab.name == "wall")
        {
            Util.getLocalPlayer().GetComponent<BuildCommands>().CmdBuildWall(transform.position);
        }
        else if (buildingPrefab.name == "pit")
        {
            Util.getLocalPlayer().GetComponent<BuildCommands>().CmdBuildPit(transform.position);
        }
        else if (buildingPrefab.name == "win")
        {
            Util.getLocalPlayer().GetComponent<BuildCommands>().CmdBuildWin(transform.position);
        }
        else
        {
            throw new System.InvalidOperationException("Unknown Building Type: " + buildingPrefab.name);
        }
    }
}
