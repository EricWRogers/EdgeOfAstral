using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLight : MonoBehaviour
{
    public Material offMat;
    public Material onMat;

    private bool on = false;

    public void Toggle()
    {
        if (on)
        {
            GetComponent<MeshRenderer>().material = offMat;
        }
        else
        {
            GetComponent<MeshRenderer>().material = onMat;
        }
    }
}
