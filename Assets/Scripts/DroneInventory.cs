using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInventory
{
    private DroneItem droneItem;

    public bool isFullError;

    public DroneInventory()
    {
        droneItem = new DroneItem(DroneItem.DroneItemType.Water,10);

        //Debug.Log("Item Type: " + droneItem.droneItemType + " Amount: " + droneItem.amount);
    }

    public void SetItem(DroneItem item)
    {
        droneItem = item;
    }

    public void AddItem(DroneItem item) 
    {
        if (droneItem.droneItemType == item.droneItemType)
        {
            droneItem.amount += item.amount;
            item.amount = 0;
        }
        else if (droneItem.droneItemType == DroneItem.DroneItemType.Empty)
        {
            droneItem.droneItemType = item.droneItemType;
            droneItem.amount = item.amount;
            item.amount = 0;
        }
        else if (droneItem.droneItemType != item.droneItemType)
        {
            Debug.Log("Drone full");
            isFullError = true;            
        }
        else
        {
            throw new System.Exception("DroneInventory.AddItem.error");
        }
    }

    public DroneItem RemoveItem()
    {
        DroneItem returnItem = new DroneItem(droneItem.droneItemType, droneItem.amount);
        droneItem.droneItemType = DroneItem.DroneItemType.Empty;
        droneItem.amount = 0;        
        return returnItem;
    }

    public DroneItem GetItem() 
    {
        return droneItem;
    }
    
    override
    public string ToString() 
    {
        if (droneItem.droneItemType != DroneItem.DroneItemType.Empty)
        {
            return droneItem.amount + "x " + droneItem.droneItemType;
        }
        else
        {
            return "empty";
        }
    }

    /*public bool isEmpty() 
    {
        return droneItem == null;
    }*/

    public bool hasWater() 
    {
        return droneItem.droneItemType == DroneItem.DroneItemType.Water && droneItem.amount >= 1;
    }

    public bool hasSeed() 
    {
        return droneItem.droneItemType == DroneItem.DroneItemType.Seed && droneItem.amount >= 1;
    }

    public void decreaseAmount() 
    {
        droneItem.amount -= 1;
        if (droneItem.amount == 0) 
        {
            droneItem.droneItemType = DroneItem.DroneItemType.Empty;
        }
    }

}
