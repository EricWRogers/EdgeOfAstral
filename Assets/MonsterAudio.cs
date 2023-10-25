using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;
using OmnicatLabs.Timers;


public class MonsterAudio : MonoBehaviour
{
    public float growlIntervalMin = 20f;
    public float growlIntervalMax = 45f;

    private int previousTimer;

    private void PostPlay()
    {
        var rand = RandTime();
        Debug.Log(rand);
        previousTimer = TimerManager.Instance.CreateTimer(rand, PlaySound);
    }

    private float RandTime()
    {
        return Random.Range(growlIntervalMin, growlIntervalMax);
    }

    public void PlaySound()
    {
        var rand = RandTime();
        Debug.Log(rand);
        AudioManager.Instance.Play("MonsterGrowl", gameObject);
        TimerManager.Instance.CreateTimer(rand, PlaySound);
    }
}
