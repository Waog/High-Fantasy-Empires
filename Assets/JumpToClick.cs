using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JumpToClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp (0)) {
		
			Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			clickPositionOnFloor.z = 0;
			transform.position = clickPositionOnFloor;
		}
	}
}
