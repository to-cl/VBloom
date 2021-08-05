using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour
{
    public GameObject plant;
    //public PlantObject plant;
    public int maxPlantStages = 3;
    public float timeBtwStages = 2f;

    private bool isPlanted = false;
    private int plantStage = 0;
    private float timer;

    private bool isDry = false;
    private Renderer rend;

    private Color dryColor;
    private Color wetColor;

    private float waterTimer;
    private float timeBtwWater = 10f;

    private bool waterRequested = false;    

    private ClickableObject co;

    private PlotController[] plots;

    private bool plantRequested = false;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        co = GetComponent<ClickableObject>();
        plots = GameObject.FindObjectsOfType<PlotController>();

        dryColor = new Color(1f, 1f, 1f);        
        wetColor = new Color(0.7f, 0.7f, 0.7f);

        rend.material.color = wetColor;
    }

    void FixedUpdate()
    {
        if (isPlanted) 
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < maxPlantStages && !isDry) 
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }

        if (!isDry) 
        {
            waterTimer -= Time.deltaTime;
            if (waterTimer < 0) 
            {
                waterTimer = timeBtwWater;

                Dry();
            }
        }

        if (waterRequested && co.isDroneNear() && co.dc.droneInventory.hasWater()) 
        {            
            Water();            
        }

        if (plantRequested && co.isDroneNear() && co.dc.droneInventory.hasSeed()) 
        {
            Plant();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SphereCollider>()) {
        if (isPlanted)
        {
            if (plantStage == maxPlantStages) 
            {
                Harvest();
            }
        }
        else 
        {
            System.Threading.Thread.Sleep(2000);
            other.isTrigger = true;
            System.Threading.Thread.Sleep(2000);
            Plant();
        }    
        }    
    }

    private void OnMouseDown()
    {
        switch (co.dc.droneInventory.GetItem().droneItemType) 
        {
            case DroneItem.DroneItemType.Water:
                foreach (PlotController pc in plots)
                {
                    pc.waterRequested = false;
                }

                if (isDry)
                {
                    waterRequested = true;
                }
                break;
            case DroneItem.DroneItemType.Seed:
                if (isPlanted)
                {
                    if (plantStage == maxPlantStages)
                    {
                        Harvest();
                    }
                }
                else
                {
                    Plant();
                }
                break;
            default:
                break;        
        }
      
    }

    void Harvest() 
    {
        plant.SetActive(false);
        isPlanted = false;
    }

    void Plant() 
    {
        print("Plant: " + plant.GetType());
        plant.SetActive(true);
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        isPlanted = true;
        co.dc.droneInventory.decreaseAmount();
        co.dc.updateUIInventory();
    }

    void Water() 
    {
        //StartCoroutine(waitWater());
        rend.material.color = wetColor;
        isDry = false;
        waterRequested = false;
        co.dc.droneInventory.decreaseAmount();
        co.dc.updateUIInventory();
    }

    /*IEnumerator waitWater() 
    {
        yield return new WaitForSeconds(1.6f);
        rend.material.color = wetColor;
        isDry = false;
    }*/

    void Dry() 
    {
        rend.material.color = dryColor;
        isDry = true;
    }

    void UpdatePlant() 
    {
        int factor = 1;
        if (plant.tag == "Tomato") 
        {
            factor = 100;
        }

        if (plantStage == 0)
        {
            plant.transform.localScale = Vector3.one * 0.5f * factor;
        }
        else 
        {
            plant.transform.localScale = Vector3.one * plantStage * factor;
        }
    }
}
