using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuildingFactory : MonoBehaviour {

	public Inventory inventory;
	public GameObject buildingPrefab;
	private bool _nextClickPlacesBuilding = false;
	public GameObject grid;

	public void nextClickBuildsPrefab() {
		_nextClickPlacesBuilding = true;
		grid.SetActive(_nextClickPlacesBuilding);
	}

	void Update ()
	{
		if (_nextClickPlacesBuilding && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp (0)) {
			createBuildingUnderMouse ();
			inventory.wood--;
			_nextClickPlacesBuilding = false;
			grid.SetActive(_nextClickPlacesBuilding);
		}
	}

	private void createBuildingUnderMouse() {
		Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		clickPositionOnFloor.z = 0;
		clickPositionOnFloor.x = Mathf.RoundToInt (clickPositionOnFloor.x);
		clickPositionOnFloor.y = Mathf.RoundToInt (clickPositionOnFloor.y);
		GameObject wall = (GameObject)Instantiate (buildingPrefab);
		wall.transform.position = clickPositionOnFloor;
	}
}
