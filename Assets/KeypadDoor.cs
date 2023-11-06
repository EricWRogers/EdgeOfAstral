using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Tween;
using OmnicatLabs.Audio;

public class KeypadDoor : MonoBehaviour, ISaveable
{
    public Transform doorPivot;
    private Quaternion originalOrientation;

    private void Start()
    {
        originalOrientation = doorPivot.rotation;
    }

    public void StartTracking()
    {
        SaveManager.Instance.Track(this);
    }

    public void OnReset()
    {
        doorPivot.rotation = originalOrientation;
    }

    public void OnTrack()
    {
        
    }

    public void Open()
    {
        doorPivot.TweenYRot(60f, 2f);
        AudioManager.Instance.Play("Door", gameObject);
    }
}
