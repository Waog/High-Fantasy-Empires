using UnityEngine;
using System.Collections;

public class PrefabGenerator : MonoBehaviour {

	public GameObject prefab;
	public int initialAmount;
	public GameObject area;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < initialAmount; i++) {
			GameObject obj = (GameObject)Instantiate (prefab);
			float x = Random.Range (area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
			float y = Random.Range (area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
			int roundedX = Mathf.RoundToInt (x);
			int roundedY = Mathf.RoundToInt (y);
			obj.transform.position = new Vector3(roundedX, roundedY, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
