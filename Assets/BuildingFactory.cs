using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuildingFactory : MonoBehaviour
{
    enum State { Idle, BuildingSelected, Drawing }

    public Inventory inventory;
    public GameObject buildingPrefab;
    private State state = State.Idle;
    public GameObject grid;
    public GameObject blueprint;
    Vector3 startPos;

    public void nextClickBuildsPrefab()
    {
        switchToBuildingSelectedState();
    }

    void Update()
    {
        if (state == State.Drawing)
        {
            destroyPreviousBlueprints();
            createNewBlueprints();
        }


        if (isDrawingConditionMet())
        {
            switchToDrawingState();
            startPos = getMousePosInGrid();
        }
        else if (isIdleConditionMet())
        {
            switchToIdleState();
            replaceAllBlueprintsByRealBuildings();
        }
    }

    private void createNewBlueprints()
    {
        Transform bluePrints = transform.FindChild("bluePrints");
        Vector3 endPos = getMousePosInGrid();
        float length = (endPos - startPos).magnitude;
        Vector3 direction = (endPos - startPos).normalized;
        Vector3 lastPlacement = new Vector3(0, 0, -1); // aka undefined;
        for (int i = 0; i <= length; i++)
        {
            Vector3 nextPos = startPos + i * direction;
            nextPos.x = Mathf.RoundToInt(nextPos.x);
            nextPos.y = Mathf.RoundToInt(nextPos.y);
            if (lastPlacement != nextPos)
            {
                GameObject aBlueprint = (GameObject)Instantiate(blueprint);
                aBlueprint.transform.SetParent(bluePrints);
                aBlueprint.transform.position = nextPos;
                lastPlacement = nextPos;
            }
        }
    }

    private void destroyPreviousBlueprints()
    {
        Transform bluePrints = transform.FindChild("bluePrints");
        foreach (Transform oldBluePrint in bluePrints)
        {
            GameObject.Destroy(oldBluePrint.gameObject);
            oldBluePrint.name = "toBeDestroyed";
        }
    }

    private void switchToBuildingSelectedState()
    {
        state = State.BuildingSelected;
        grid.SetActive(true);
    }

    private void switchToDrawingState()
    {
        state = State.Drawing;
    }

    private void switchToIdleState()
    {
        state = State.Idle;
        grid.SetActive(false);
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
        Transform bluePrints = transform.FindChild("bluePrints");
        foreach (Transform oldBluePrint in bluePrints)
        {
            if (oldBluePrint.name != "toBeDestroyed")
            {
                GameObject wall = (GameObject)Instantiate(buildingPrefab);
                wall.transform.position = oldBluePrint.transform.position;
                GameObject.Destroy(oldBluePrint.gameObject);
                inventory.wood--;
            }
        }
    }
}
