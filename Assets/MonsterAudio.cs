using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;


public class MonsterAudio : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.Play("MonsterRoar", gameObject);
    }
}
