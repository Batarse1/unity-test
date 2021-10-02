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

    public List<Item> items = new List<Item>();
    private int maxSpace = 2;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (!(maxSpace > items.Count))
            {
                Debug.Log("Not enough space");
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
    
    public void Remove(Item item)
    {
        items.Remove(item);
        
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
