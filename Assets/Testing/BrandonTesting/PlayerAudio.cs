using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;

public class PlayerAudio : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.Play("PlayerBreath");
    }
}
