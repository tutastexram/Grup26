using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>(); 
    public Sprite defaultItemIcon; 

    void Start()
    {
        foreach (InventorySlotUI slot in inventorySlots)
        {
            if (slot != null) 
            {
                slot.ClearSlot();
            }
        }
    }

    public bool AddItem(Sprite itemIcon, int count)
    {
        if (itemIcon == null) return false;

        foreach (InventorySlotUI slot in inventorySlots)
        {
            if (slot != null && slot.GetItemIcon() == itemIcon)
            {
                slot.SetSlot(itemIcon, slot.GetItemCount() + count);
                return true;
            }
        }

        foreach (InventorySlotUI slot in inventorySlots)
        {
            if (slot != null && slot.GetItemIcon() == null) 
            {
                slot.SetSlot(itemIcon, count);
                return true;
            }
        }
        return false; 
    }

    public bool RemoveItem(Sprite itemIcon, int count)
    {
        if (itemIcon == null) return false;

        foreach (InventorySlotUI slot in inventorySlots)
        {
            if (slot != null && slot.GetItemIcon() == itemIcon && slot.GetItemCount() >= count)
            {
                slot.SetSlot(itemIcon, slot.GetItemCount() - count);
                if (slot.GetItemCount() == 0) 
                {
                    slot.ClearSlot();
                }
                return true;
            }
        }
        return false;
    }

    public void HandleItemPickedUp(GameObject pickedItem, Sprite itemIcon)
    {
        if (pickedItem == null) return;

        if (AddItem(itemIcon, 1)) 
        {
            Destroy(pickedItem); 
        }
    }
}
