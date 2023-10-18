using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandNumGen : MonoBehaviour
{
    public float RandNum = 0f;
    public TMP_Text numText;

    public float test = 10f;

    
    void Start()
    {
        RandNum = Random.Range(1111, 9999);
        Debug.Log(RandNum);
        numText.text = RandNum.ToString();
    }

   
    void Update()
    {
     
    }
}
