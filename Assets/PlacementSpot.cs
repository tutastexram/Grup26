using UnityEngine;

public class PlacementSpot : MonoBehaviour
{
    public string requiredItemName;
    public Transform placementPosition;

    public bool CanPlaceItem(GameObject itemToPlace)
    {
        Item item = itemToPlace.GetComponent<Item>();
        return item != null && item.itemName == requiredItemName;
    }

    public void ItemPlaced(Item placedItem)
    {
        Debug.Log(placedItem.itemName + " doğru yere bırakıldı!");
        // Burada görev tamamlandıysa tetikleyebilirsin
    }
}
