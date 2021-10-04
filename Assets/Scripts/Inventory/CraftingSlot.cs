using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Image icon;

    Item item;

    public string GetName()
    {
        return item.name;
    }
    public bool isNotNull()
    {
        if(item != null)
        {
            return true;
        }
        else {
            return false;
       }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.image;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnRemoveItem()
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
            Inventory.instance.RemoveCraftingItem(item);
        }
    }
}
