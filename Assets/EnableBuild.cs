using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableBuild : MonoBehaviour
{

	public Inventory inventory;

	// Update is called once per frame
	void Update ()
	{
		Button buttonScript = gameObject.GetComponent<Button> ();
		buttonScript.interactable = inventory.wood > 0;
	}
}
