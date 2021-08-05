using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI itemAmountText;
    public float productionRate = 1f;

    private DroneItem item;
    private ClickableObject co;

    private ShopController[] shops;

    private bool shopRequest = false;


    void Start()
    {
        co = GetComponent<ClickableObject>();
        shops = GameObject.FindObjectsOfType<ShopController>();

        switch (gameObject.tag)
        {
            case "WaterShop":
                item = new DroneItem(DroneItem.DroneItemType.Water, 0);
                break;
            case "SeedShop":
                item = new DroneItem(DroneItem.DroneItemType.Seed, 0);
                break;
            default:
                break;
        }
        InvokeRepeating("increaseAmount", 5f, productionRate);
    }

    private void Update()
    {
        updateText();
    }

    void FixedUpdate()
    {
        if (shopRequest && co.isDroneNear())
        {
            Shop();
        }
    }

    private void OnMouseDown()
    {
        foreach (ShopController sc in shops)
        {
            sc.shopRequest = false;
        }
        shopRequest = true;
    }

    void updateText() 
    {
        itemAmountText.text = item.amount + "";
    }
     
    void increaseAmount()
    {
        item.amount += 5;
    }

    void Shop() 
    {
        co.dc.droneInventory.AddItem(item);
        co.dc.updateUIInventory();
        /*switch (gameObject.tag) 
        {
            case "WaterShop":
                
                break;
            case "SeedShop":

                break;
            default:
                break;
        }*/
        shopRequest = false;
    }
}
