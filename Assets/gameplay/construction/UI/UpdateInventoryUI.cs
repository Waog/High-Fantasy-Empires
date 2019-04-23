﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateInventoryUI : MonoBehaviour
{

    public Text inventoryUI;
    public Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (inventory)
        {
            inventoryUI.text = inventory.wood + " Wood";
            inventoryUI.text += "\n" + inventory.gems + " Gems";
        }
    }
}
