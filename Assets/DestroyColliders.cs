﻿using UnityEngine;
using System.Collections;

public class DestroyColliders : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		inventory.wood++;
		Destroy (collision.gameObject);
	}
}
