using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneItem
{
    public enum DroneItemType
    {
        Water,
        Seed,
        Pesticide,
        Fertiliser,
        Empty
    }

    public DroneItemType droneItemType;
    public int amount;

    public DroneItem(DroneItemType dit, int a) 
    {
        droneItemType = dit;
        amount = a;
    }

    override
    public string ToString() 
    {
        return amount + "x " + droneItemType;
    }
}
