﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class BuildingFactory : MonoBehaviour
{
    enum State { Idle, BuildingSelected, Drawing }

    public GameObject grid;

    private GameObject blueprintPrefab;
    private Vector3 startPos;
    private State state = State.Idle;
    private Transform blueprintsParent;

    void Start()
    {
        blueprintsParent = new GameObject("bluePrints").transform;
        blueprintsParent.SetParent(transform);
    }

    public void nextClickBuildsPrefab(GameObject blueprintPrefab)
    {
        this.blueprintPrefab = blueprintPrefab;
        switchToBuildingSelectedState();
    }

    void Update()
    {
        if (isDrawingConditionMet())
        {
            startPos = getMousePosInGrid();
            switchToDrawingState();
        }
        else if (isIdleConditionMet())
        {
            replaceAllBlueprintsByRealBuildings();
            switchToIdleState();
        }
        else if (state == State.Drawing)
        {
            destroyBlueprints();
            createNewBlueprints();
        }
    }

    private void createNewBlueprints()
    {
        Vector3 endPos = getMousePosInGrid();
        float selectedLength = (endPos - startPos).magnitude;
        Vector3 direction = (endPos - startPos).normalized;
        Vector3 lastPlacement = new Vector3(0, 0, -1); // aka undefined;
        for (int i = 0; i < selectedLength + 0.5; i++)
        {
            Vector3 nextPos = startPos + i * direction;
            nextPos.x = Mathf.RoundToInt(nextPos.x);
            nextPos.y = Mathf.RoundToInt(nextPos.y);
            if (lastPlacement != nextPos)
            {
                GameObject aBlueprint = (GameObject)Instantiate(blueprintPrefab);
                aBlueprint.transform.SetParent(blueprintsParent);
                aBlueprint.transform.position = nextPos;
                lastPlacement = nextPos;
            }
        }
    }

    private void destroyBlueprints()
    {
        foreach (Transform blueprint in blueprintsParent)
        {
            GameObject.Destroy(blueprint.gameObject);
        }
    }

    private void switchToBuildingSelectedState()
    {
        state = State.BuildingSelected;
        grid.SetActive(true);
        Util.getLocalPlayer().GetComponent<JumpToClick>().ignoreClicks = true;
    }

    private void switchToDrawingState()
    {
        state = State.Drawing;
    }

    private void switchToIdleState()
    {
        state = State.Idle;
        grid.SetActive(false);
        Util.getLocalPlayer().GetComponent<JumpToClick>().ignoreClicks = false;
    }

    private bool isDrawingConditionMet()
    {
        return state == State.BuildingSelected && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0);
    }

    private bool isIdleConditionMet()
    {
        return state == State.Drawing && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp(0);
    }

    private Vector3 getMousePosInGrid()
    {
        Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPositionOnFloor.x = Mathf.RoundToInt(clickPositionOnFloor.x);
        clickPositionOnFloor.y = Mathf.RoundToInt(clickPositionOnFloor.y);
        clickPositionOnFloor.z = 0;
        return clickPositionOnFloor;
    }

    private void replaceAllBlueprintsByRealBuildings()
    {
        foreach (Transform blueprint in blueprintsParent)
        {
            blueprint.GetComponent<OrderBuild>().build();
            GameObject.Destroy(blueprint.gameObject);
        }
    }
}
