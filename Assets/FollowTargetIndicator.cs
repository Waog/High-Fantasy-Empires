using UnityEngine;
using System.Collections;

public class FollowTargetIndicator : MonoBehaviour {

	public Transform target;
	public float speed = 1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 direction = target.position - transform.position;
			Vector3 normalizedDirection = direction.normalized;
			Vector3 intermediateTargetDirection = Time.deltaTime * normalizedDirection * speed;
			Vector3 intermediateTargetDirectionClamped = Vector3.ClampMagnitude (intermediateTargetDirection, direction.magnitude);
			transform.position += intermediateTargetDirectionClamped;
		}
	}
}
