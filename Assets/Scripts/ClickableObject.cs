using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public DroneController dc;
    private Collider col;

    private Outline outline;
    private Outline[] outlines;   

    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        outline = gameObject.GetComponent<Outline>();
        outlines = GameObject.FindObjectsOfType<Outline>();        

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 0f;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        foreach (Outline o in outlines) 
        {
            o.OutlineWidth = 0f;
            o.OutlineColor = Color.white;
        }

        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 3f;

        Vector3 currentPosition = gameObject.transform.position;
        Vector3 newPositon = new Vector3(currentPosition.x, col.bounds.size.y + 1, currentPosition.z);

        dc.clickedPosition = newPositon;
    }

    private void OnMouseEnter()
    {
        if (outline.OutlineColor != Color.red)
        {
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 3f;
        }
    }

    private void OnMouseExit()
    {
        if (outline.OutlineColor != Color.red)
        {
            outline.OutlineWidth = 0f;
            outline.OutlineColor = Color.white;
        }
    }

    public bool isDroneNear() 
    {
        Vector3 dronePosition = new Vector3(dc.transform.position.x, 1, dc.transform.position.z);
        Vector3 goPosition = new Vector3(gameObject.transform.position.x,1, gameObject.transform.position.z);

        return Vector3.Distance(dronePosition, goPosition) < 0.5f;
    }
}
