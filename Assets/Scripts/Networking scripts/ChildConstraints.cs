using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildConstraints : MonoBehaviour
{
    [SerializeField] GameObject cameraPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
       // transform.rotation = Quaternion.identity;
        transform.rotation = new Quaternion(0f, cameraPosition.transform.rotation.y, 0f, 0f);
        transform.position = new Vector3(cameraPosition.transform.position.x, 
        0.0f, cameraPosition.transform.position.z);
    }

}
