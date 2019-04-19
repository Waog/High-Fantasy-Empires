using UnityEngine;
using System.Collections;

public class CollectColletables : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Collectable") {
			inventory.wood++;
			Destroy (collision.gameObject);
		}
	}
}
