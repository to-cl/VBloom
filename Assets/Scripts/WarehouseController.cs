using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarehouseController : MonoBehaviour
{
    public TextMeshProUGUI wareHouseText;

    private List<DroneItem> itemList;

    private ClickableObject co;

    private bool storeRequested = false;

    // Start is called before the first frame update
    void Start()
    {
        co = GetComponent<ClickableObject>();
        itemList = new List<DroneItem>();
        //itemList.Add(new DroneItem(DroneItem.DroneItemType.Seed, 10));
        //itemList.Add(new DroneItem(DroneItem.DroneItemType.Water, 10));
        updateText();
    }

    private void Update()
    {
        if (storeRequested && co.isDroneNear()) 
        {
            Store();
        }
    }

    void updateText() 
    {
        wareHouseText.text = "Warehouse:\n";
        foreach (DroneItem di in itemList) 
        {
            if (di.droneItemType != DroneItem.DroneItemType.Empty) 
            {
                wareHouseText.text += di.ToString() + "\n";
            }
        }
    }

    public void addItem(DroneItem item) 
    {
        foreach (DroneItem di in itemList) 
        {
            if (item.droneItemType == di.droneItemType) 
            {
                di.amount += item.amount;
                updateText();
                return;
            }
        }
        itemList.Add(item);
        updateText();
    }

    private void OnMouseDown()
    {
        storeRequested = true;
    }

    void Store() 
    {
        addItem(co.dc.droneInventory.RemoveItem());
        co.dc.updateUIInventory();
    }
}
