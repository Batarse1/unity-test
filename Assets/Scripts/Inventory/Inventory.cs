using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
        }
        else
        {
            instance = this;
        }
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnCraftingItemChanged();
    public OnCraftingItemChanged onCraftingItemChangedCallback;

    public List<Item> items = new List<Item>();
    public List<Item> craftingItems = new List<Item>();

    private int itemsMaxSpace = 12;
    private int craftingItemsMaxSpace = 3;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (!(itemsMaxSpace > items.Count))
            {
                Debug.Log("Not enough space for a new item");
                return false;
            }
            else
            {
                items.Add(item);

                if(onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
            }
        }
        return true;
    }

    public bool AddCraftingItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (!(craftingItemsMaxSpace > craftingItems.Count))
            {
                Debug.Log("Not enough space for a new crafting item");
                return false;
            }
            else
            {
                craftingItems.Add(item);

                if (onCraftingItemChangedCallback != null)
                {
                    onCraftingItemChangedCallback.Invoke();
                }
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    public void RemoveCraftingItem(Item item)
    {
        craftingItems.Remove(item);

        if (onCraftingItemChangedCallback != null)
        {
            onCraftingItemChangedCallback.Invoke();
        }
    }

    public void ClearCraftingItem()
    {
        craftingItems.Clear();
        
        if (onCraftingItemChangedCallback != null)
        {
            onCraftingItemChangedCallback.Invoke();
        }
    }

}
