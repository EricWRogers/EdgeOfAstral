using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandNumGen : MonoBehaviour
{
    public float RandNum = 0f;
    void Start()
    {
        RandNum = Random.Range(1111, 9999);
        Debug.Log(RandNum);
    }

   
    void Update()
    {
        
    }
}
