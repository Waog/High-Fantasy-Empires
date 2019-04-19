using UnityEngine;
using System.Collections;

public class FollowObject : FollowTransform {

	public GameObject targetObj;

	// Use this for initialization
	void Start () {
		target = targetObj.transform;
	}
}
