using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CreateWall : MonoBehaviour {

	public GameObject wallPrefab;
	private bool _nextClickBuildsWall = false;

	public void nextClickBuildsWall() {
		_nextClickBuildsWall = true;
	}

	void Update ()
	{
		if (_nextClickBuildsWall && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp (0)) {
			createWall ();
			_nextClickBuildsWall = false;
		}
	}

	public void createWall() {
		Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		clickPositionOnFloor.z = 0;
		GameObject wall = (GameObject)Instantiate (wallPrefab);
		wall.transform.position = clickPositionOnFloor;
	}
}
