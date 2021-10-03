using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;

    Item item;

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

    public void OnRemoveButton()
    {
        if(item != null){
            Debug.Log("Removing " + item.name);
        }
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void CraftItem()
    {
        if (item != null)
        {
            Debug.Log("Crafting with " + item.name);
        }
    }
}
