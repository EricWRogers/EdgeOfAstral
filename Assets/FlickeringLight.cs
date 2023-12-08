using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    IEnumerator FlickerLight()
    {
        while (true)
        {
            //isFlickering = true;
            GetComponent<Light>().enabled = false;
            timeDelay = Random.Range(0.05f, 2.2f);
            yield return new WaitForSeconds(timeDelay);
            GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(timeDelay);
            //isFlickering = false;
        }
    }

    private void PostPlay()
    {
        StartCoroutine(FlickerLight());
    }
  
}
