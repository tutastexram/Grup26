using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    public LayerMask interactableLayer;

    private InventoryManager inventoryManager;
    private GameObject heldItem = null;

    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
                TryPickUpItem();
            else
                TryPlaceItem();
        }
    }

    void TryPickUpItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("PickableItem"))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    bool added = inventoryManager.AddItem(item.itemIcon, 1);
                    if (added)
                    {
                        heldItem = item.gameObject;
                        heldItem.SetActive(false);
                        Debug.Log(item.itemName + " alındı.");
                    }
                }
            }
        }
    }

    void TryPlaceItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("PlacementSpot"))
            {
                PlacementSpot spot = hit.collider.GetComponent<PlacementSpot>();
                if (spot != null && spot.CanPlaceItem(heldItem))
                {
                    inventoryManager.RemoveItem(heldItem.GetComponent<Item>().itemIcon, 1);
                    heldItem.transform.position = spot.placementPosition.position;
                    heldItem.SetActive(true);
                    Debug.Log("Item bırakıldı.");
                    spot.ItemPlaced(heldItem.GetComponent<Item>());
                    heldItem = null;
                }
            }
        }
    }
}
