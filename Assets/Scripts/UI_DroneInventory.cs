using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_DroneInventory : MonoBehaviour
{
    //public DroneInventory droneInventory;
    public TextMeshProUGUI amountText;

    public Sprite waterSprite;
    public Sprite seedSprite;

    public Image image;


    /*private void Update()
    {
        if (droneInventory.isFullError) 
        {
            StartCoroutine(flashBackground());
        }
    }

    IEnumerator flashBackground() 
    {
        Color currentColor = image.color;
        image.color = Color.red;
        yield return new WaitForSeconds(1);
        image.color = currentColor;
        droneInventory.isFullError = false;
    }*/

    public void SetDroneInventory(DroneInventory inv)
    {
        image.enabled = true;
        amountText.text = inv.GetItem().amount > 0 ? inv.GetItem().amount + "" : "";
        switch (inv.GetItem().droneItemType) 
        {
            case DroneItem.DroneItemType.Water:
                image.sprite = waterSprite;
                break;
            case DroneItem.DroneItemType.Seed:
                image.sprite = seedSprite;
                break;
            case DroneItem.DroneItemType.Empty:
                image.enabled = false;                
                break;
            default:
                break;
        }       
    }
}
