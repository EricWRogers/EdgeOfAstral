using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;
using UnityEditor.Timeline.Actions;

public class RubbleSound : MonoBehaviour
{
    public void Sound()
    {
        AudioManager.Instance.Play("RubbleCrash");
    }
}
