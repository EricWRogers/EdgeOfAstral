using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using OmnicatLabs.Timers;

public class CameraShakeController : MonoBehaviour
{
    public float shakeDuration;
    public float intensity;

    private CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin noise;
    private bool canShake = true;

    private void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        ResetIntensity();
    }

    /// <summary>
    /// Causes a camera shake with the values publicly set on the script
    /// </summary>
    public void CauseShake()
    {
        noise.m_AmplitudeGain = intensity;
        TimerManager.Instance.CreateTimer(shakeDuration, ResetIntensity);
    }

    /// <summary>
    /// Causes a camera shake with the provided values instead of the publicly set values.
    /// </summary>
    /// <param name="_duration">The duration of the camera shake.</param>
    /// <param name="_intensity">The intensity of the camera shake.</param>
    public void CauseShake(float _duration, float _intensity)
    {
        noise.m_AmplitudeGain = _intensity;
        TimerManager.Instance.CreateTimer(_duration, ResetIntensity);
    }

    public void ResetIntensity()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
