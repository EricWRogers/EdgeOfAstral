using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;
using UnityEditor.Timeline.Actions;

public class RubbleSound : MonoBehaviour
{
    Animator anim;
    AnimationClip clip;
    public void Sound()
    {
       Timeline

        AudioManager.Instance.Play("RubbleCrash");
    }
}
