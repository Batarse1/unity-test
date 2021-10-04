using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public Image icon;

    Item item;

    // Start is called before the first frame update
    public void Craft(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.image;
        icon.enabled = true;
    }
    public void CraftNone()
    {
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnCraftItem()
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
            CraftNone();
            item = null;
            Inventory.instance.ClearCraftingItem();
        }
    }
}
