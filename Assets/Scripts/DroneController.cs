using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    [SerializeField] private UI_DroneInventory uiDroneInventory;

    public float speed = 0f;

    private Rigidbody rb;
    public Vector3 clickedPosition;
    private Rigidbody currentRb;
    private float droneHeight = 1f;

    public DroneInventory droneInventory;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //set starting position of the drone to (-12, 4, 0)
        clickedPosition = new Vector3(-12, 4, 0);

        droneInventory = new DroneInventory();
        uiDroneInventory.SetDroneInventory(droneInventory);
    }

    public void updateUIInventory()
    {
        uiDroneInventory.SetDroneInventory(droneInventory);
    }    

    /*void OnClick()
    {
        // calculate a Vector2 for the current mouse position
        Vector2 position = new Vector2(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y);
        // convert the mouse position to a ray with the camera as origin
        Ray ray = Camera.main.ScreenPointToRay(position);
        Debug.DrawRay(ray.origin, ray.direction * 20, new Color(1f,0f,0f),5f);

        RaycastHit hit;
        // if the raycast hits something it creats (out) a hit
        if (Physics.Raycast(ray, out hit))
        {
            // if a rigidbody is hit
            if (hit.rigidbody != null)
            {
                // the current clicked position is set to intersection between the ray and the rb
                clickedPosition = new Vector3(hit.point.x, droneHeight, hit.point.z);
                currentRb = hit.rigidbody;
                //Debug.Log(hit.rigidbody.tag);
            }
        }

    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        switch (other.tag) 
        {
            case "SeedShop":                
                DroneItem seedShopItem = other.GetComponentInParent<SeedShopController>().GetDroneItem();               
                droneInventory.AddItem(seedShopItem);
                //seedShopItem.amount = 0;
                uiDroneInventory.SetDroneInventory(droneInventory);                
                break;
            case "WaterShop":
                DroneItem waterShopItem = other.GetComponentInParent<WaterShopController>().GetDroneItem();
                droneInventory.AddItem(waterShopItem);
                //waterShopItem.amount = 0;
                uiDroneInventory.SetDroneInventory(droneInventory);
                break;
            case "Warehouse":
                other.GetComponent<WarehouseController>().addItem(droneInventory.RemoveItem());
                uiDroneInventory.SetDroneInventory(droneInventory);
                break;            
            default:
                break;
        }
    }*/

    void FixedUpdate()
    {
        // calculate vector between the current position and the new position
        Vector3 movement = clickedPosition - rb.transform.position;
        // set the y coord to zero (no vertical movement)
        movement.y = 0;
        // calulate the distance of the vector
        float dist = Vector3.Distance(clickedPosition, rb.transform.position);
        // calulate the speed of the drone according to the globel variable speed and the distance to the new position
        // the nearer you get, the solwer the speed
        float step = speed * Time.deltaTime * (dist/2);
        // move the drone towards the new position with the calculatet step size
        transform.position = Vector3.MoveTowards(transform.position, clickedPosition, step);

        /*if (currentRb != null && Vector3.Distance(clickedPosition, rb.transform.position) < 0.5f) 
        {
            switch (currentRb.tag) 
            {
                case "SeedShop":
                    //Debug.Log("On SeedShop");
                    DroneItem di = new DroneItem(DroneItem.DroneItemType.Seed, 10);
                    droneInventory.AddItem(di);
                    uiDroneInventory.SetDroneInventory(droneInventory);
                    currentRb = null;
                    break;
                default:
                    break;
            }
        }*/
    }
}
