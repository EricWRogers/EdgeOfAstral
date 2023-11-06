using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;

public class DestructionAudio : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.Play("Destruction");
    }
}
