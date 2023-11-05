using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class SettingsManager : MonoBehaviour
{
    public Toggle vsyncToggle;
    public Slider fovSlider;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        fovSlider.onValueChanged.AddListener(ChangeFOV);

        ToggleVSync(false);

        int highQualityIndex = System.Array.IndexOf(QualitySettings.names, "High Fidelity");

        QualitySettings.SetQualityLevel(highQualityIndex != -1 ? highQualityIndex : QualitySettings.names.Length - 1);

        PopulateResolutionDropdown();
        PopulateGraphicsDropdown();
    }

    public void ToggleVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
        Application.targetFrameRate = isOn ? 60 : -1;

        Debug.Log("VSync: " + (isOn ? "Enabled" : "Disabled") + ", Target Frame Rate: " + Application.targetFrameRate);
    }
    
    public void ChangeFOV(float fovValue)
    {
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.FieldOfView = fovValue;

            Debug.Log("Field of View changed to: " + fovValue);
        }
    }
    

    void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.width + "x" + resolution.height);
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.onValueChanged.AddListener((int index) => SetResolution(index));
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution[] resolutions = Screen.resolutions;

        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Resolution selectedResolution = resolutions[resolutionIndex];
            Debug.Log("Selected Resolution: " + selectedResolution.width + "x" + selectedResolution.height);
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        }
    }

    public void SetQualityLevel (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    void PopulateGraphicsDropdown()
    {
        string [] qualityNames = QualitySettings.names;

        // Find the index of the current quality level
        int currentQualityIndex = QualitySettings.GetQualityLevel();

        // Clear existing options and add quality levels to the dropdown
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(new List<string>(qualityNames));

        // Set the dropdown value to the current quality level
        graphicsDropdown.value = currentQualityIndex;
    }
}

