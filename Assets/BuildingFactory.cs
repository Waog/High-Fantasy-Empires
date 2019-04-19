using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuildingFactory : MonoBehaviour {

	public Inventory inventory;
	public GameObject buildingPrefab;
	private bool _nextClickBuildsWall = false;

	public void nextClickBuildsPrefab() {
		_nextClickBuildsWall = true;
	}

	void Update ()
	{
		if (_nextClickBuildsWall && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp (0)) {
			createBuildingUnderMouse ();
			inventory.wood--;
			_nextClickBuildsWall = false;
		}
	}

	private void createBuildingUnderMouse() {
		Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		clickPositionOnFloor.z = 0;
		GameObject wall = (GameObject)Instantiate (buildingPrefab);
		wall.transform.position = clickPositionOnFloor;
	}
}
