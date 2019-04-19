using UnityEngine;
using System.Collections;

public class FollowPlayer : FollowTransform {

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
}
