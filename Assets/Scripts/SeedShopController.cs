using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedShopController : MonoBehaviour
{
    public TextMeshProUGUI seedShopText;    

    public float productionRate;
    private DroneItem item;

    void Start()
    {
        item = new DroneItem(DroneItem.DroneItemType.Seed, 5);
        InvokeRepeating("increaseAmount", 5f, productionRate);
    }

    private void Update()
    {
        updateText();
    }

    void increaseAmount()
    {
        item.amount += 5;
    }

    void updateText() 
    {
        seedShopText.text = item.amount + "x " + item.droneItemType;
    }

    public DroneItem GetDroneItem() 
    {
        return item;
    }
}
