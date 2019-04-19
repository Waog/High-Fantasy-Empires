using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateInventoryUI : MonoBehaviour {

	public Text inventoryUI;
	public Inventory inventory;
	
	// Update is called once per frame
	void Update () {
		inventoryUI.text = inventory.wood + " Wood";
	}
}
