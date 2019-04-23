using UnityEngine;
using System.Collections;

public class DieInPit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Pit")) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
