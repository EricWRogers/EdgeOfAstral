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

    [HideInInspector]
    public Timer timer;
    [HideInInspector]
    public Timer footstepTimer;
    private void PostPlay()
    {
        var rand = RandTime();
        TimerManager.Instance.CreateTimer(rand, PlaySound, out timer);
        TimerManager.Instance.CreateTimer(stepInterval, PlayFootstep, out footstepTimer);
    }

    private float RandTime()
    {
        return Random.Range(growlIntervalMin, growlIntervalMax);
    }

    private void PlayFootstep()
    {
        AudioManager.Instance.Play("MonsterFootstep", gameObject);
        TimerManager.Instance.CreateTimer(stepInterval, PlayFootstep, out footstepTimer);
    }

    public void PlaySound()
    {
        var rand = RandTime();
        AudioManager.Instance.Play("MonsterGrowl", gameObject);
        TimerManager.Instance.CreateTimer(rand, PlaySound);
    }
}
