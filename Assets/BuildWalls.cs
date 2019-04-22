﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BuildWalls : NetworkBehaviour
{
    public GameObject wallPrefab;
    public GameObject pitPrefab;

    [Command]
    public void CmdExecuteTest()
    {
        GameObject wall = (GameObject)Instantiate(wallPrefab);
        NetworkServer.Spawn(wall);
    }

    [Command]
    public void CmdBuildWall(Vector3 position)
    {
        buildBuilding(wallPrefab, position);
    }

    [Command]
    public void CmdBuildPit(Vector3 position)
    {
        buildBuilding(pitPrefab, position);

    }

    private void buildBuilding(GameObject buildingPrefab, Vector3 position)
    {
        GameObject building = (GameObject)Instantiate(
            buildingPrefab,
            position,
            Quaternion.identity);

        NetworkServer.Spawn(building);

        GameObject[] allKnights = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject knight in allKnights)
        {
            if (knight.GetComponent<FollowTransform>().target == transform)
            {
                knight.GetComponent<Inventory>().wood--;
                break;
            }
        }
    }

}
