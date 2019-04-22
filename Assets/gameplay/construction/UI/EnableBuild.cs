using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableBuild : MonoBehaviour
{

    public Inventory inventory;

    void Update()
    {
        Button buttonScript = gameObject.GetComponent<Button>();
        if (inventory)
        {
            buttonScript.interactable = inventory.wood > 0;
        }
        else
        {
            buttonScript.interactable = false;
        }
    }
}
