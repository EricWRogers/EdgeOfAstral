using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }
    }

    private void PostPlay()
    {
        IEnumerator FlickerLight()
        {
            isFlickering = true;
            this.gameObject.GetComponent<Light>().enabled = false;
            timeDelay = Random.Range(0.05f, 2.2f);
            yield return new WaitForSeconds(timeDelay);
            this.gameObject.GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.05f, 2.2f);
            yield return new WaitForSeconds(timeDelay);
            isFlickering = false;
        }
    }
  
}
