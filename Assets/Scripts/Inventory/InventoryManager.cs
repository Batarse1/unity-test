using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;

    public Transform player;
    public Transform potionsTable;
    public Transform itemsParent;
    public Transform craftingItemsParent;
    public Product craftingProduct;

    public Item bigPotion;
    public Item giantPotion;

    private string craftingTableType = "none"; 

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

        var potionsTableX = player.position.x - potionsTable.position.x;
        var potionsTableY = player.position.y - potionsTable.position.y;
        if (potionsTableX<0)
        {
            potionsTableX *= -1;
        }
        if (potionsTableY < 0)
        {
            potionsTableY *= -1;
        }

        Debug.Log("Potions table x:" + potionsTableX);
        Debug.Log("Potions table y:" + potionsTableY);

        if(potionsTableX <= 2.5 && potionsTableY <= 2.5)
        {
            craftingTableType = "potionsTable";
        }
        else
        {
            craftingTableType = "none";
        }

        if (craftingSlots[0].isNotNull() && craftingSlots[1].isNotNull() && craftingSlots[2].isNotNull())
        {
            if (craftingSlots[0].GetName().Equals("potion") && craftingSlots[1].GetName().Equals("potion") && craftingSlots[2].GetName().Equals("potion"))
            {
                craftingProduct.Craft(bigPotion);
            }
            else if (craftingSlots[0].GetName().Equals("bigPotion") && craftingSlots[1].GetName().Equals("bigPotion") && craftingSlots[2].GetName().Equals("bigPotion") && craftingTableType.Equals("potionsTable"))
            {
                craftingProduct.Craft(giantPotion);
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
