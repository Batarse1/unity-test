using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;

    public Transform player;
    public Transform itemsParent;
    public Transform craftingItemsParent;
    public Product craftingProduct;

    public Item bigPotion;

    Inventory inventory;

    Slot[] slots;
    CraftingSlot[] craftingSlots;

    void Start()
    {
        inventory = Inventory.instance;

        inventory.onItemChangedCallback += UpdateUI;
        inventory.onCraftingItemChangedCallback += UpdateCraftingUI;

        slots = itemsParent.GetComponentsInChildren<Slot>();
        craftingSlots = craftingItemsParent.GetComponentsInChildren<CraftingSlot>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                slots[i].setPlayer(player);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void UpdateCraftingUI()
    {
        for (int i = 0; i < craftingSlots.Length; i++)
        {
            if (i < inventory.craftingItems.Count)
            {
                craftingSlots[i].AddItem(inventory.craftingItems[i]);
            }
            else
            {
                craftingSlots[i].ClearSlot();
            }
        }

        if (craftingSlots[0].isNotNull() && craftingSlots[1].isNotNull() && craftingSlots[2].isNotNull())
        {
            if (craftingSlots[0].GetName().Equals("potion") && craftingSlots[1].GetName().Equals("potion") && craftingSlots[2].GetName().Equals("potion"))
            {
                craftingProduct.Craft(bigPotion);
            }
            else
            {
                craftingProduct.CraftNone();
            }
        }
        else
        {
            craftingProduct.CraftNone();
        }
    }
}
