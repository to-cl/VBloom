using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant", order =1)]
[System.Serializable]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public GameObject plantModel;
    public float timeBtwStages;
}
