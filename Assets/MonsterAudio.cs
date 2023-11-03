using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Audio;
using OmnicatLabs.Timers;


public class MonsterAudio : MonoBehaviour
{
    public float growlIntervalMin = 20f;
    public float growlIntervalMax = 45f;

    public float stepInterval = .3f;

    private int previousTimer;

    private void PostPlay()
    {
        var rand = RandTime();
        previousTimer = TimerManager.Instance.CreateTimer(rand, PlaySound);
        TimerManager.Instance.CreateTimer(stepInterval, PlayFootstep);
    }

    private float RandTime()
    {
        return Random.Range(growlIntervalMin, growlIntervalMax);
    }

    private void PlayFootstep()
    {
        AudioManager.Instance.Play("MonsterFootstep", gameObject);
        TimerManager.Instance.CreateTimer(stepInterval, PlayFootstep);
    }

    public void PlaySound()
    {
        var rand = RandTime();
        AudioManager.Instance.Play("MonsterGrowl", gameObject);
        TimerManager.Instance.CreateTimer(rand, PlaySound);
    }
}
