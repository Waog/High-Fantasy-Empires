using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuildingFactory : MonoBehaviour
{

    public Inventory inventory;
    public GameObject buildingPrefab;
    private bool _nextClickPlacesBuilding = false;
    private bool startedBuilding = false;
    public GameObject grid;
    public GameObject blueprint;
    Vector3 startPos;
    Vector3 endPos;

    public void nextClickBuildsPrefab()
    {
        _nextClickPlacesBuilding = true;
        grid.SetActive(_nextClickPlacesBuilding);
    }

    void Update()
    {
        if (startedBuilding)
        {
            endPos = getMousePosInGrid();
            float length = (endPos - startPos).magnitude;
            Vector3 direction = (endPos - startPos).normalized;
            Transform bluePrints = transform.FindChild("bluePrints");
            foreach (Transform oldBluePrint in bluePrints)
            {
                GameObject.Destroy(oldBluePrint.gameObject);
                oldBluePrint.name = "toBeDestroyed";
            }
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


        if (_nextClickPlacesBuilding && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            _nextClickPlacesBuilding = false;
            startedBuilding = true;
            startPos = getMousePosInGrid();
            grid.SetActive(true);
        }
        else if (startedBuilding && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp(0))
        {
            startedBuilding = false;
            grid.SetActive(false);
            replaceAllBlueprintsByRealBuildings();
        }
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
