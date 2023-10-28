using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLight : MonoBehaviour, ISaveable
{
    public Material offMat;
    public Material onMat;

    private bool on = false;

    public void StartTracking()
    {
        SaveManager.Instance.Track(this);
    }

    public void OnReset()
    {
        Debug.Log("Reset Light");
        GetComponent<MeshRenderer>().material = offMat;
    }

    public void OnTrack()
    {
        
    }

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
