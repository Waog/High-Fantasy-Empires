using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableBuild : MonoBehaviour
{

    public Inventory available;
    public Inventory price;


    void Update()
    {
        Button buttonScript = gameObject.GetComponent<Button>();
        if (available)
        {
            buttonScript.interactable = available.contains(price);
        }
        else
        {
            buttonScript.interactable = false;
        }
    }
}
