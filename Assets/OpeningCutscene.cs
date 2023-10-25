using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OmnicatLabs.Audio;
using System.Reflection;
using System.Linq;

public class OpeningCutscene : MonoBehaviour
{
    public CameraShakeController shaker;
    public TutorialTextTrigger firstTutorial;
    public CanvasGroup staminaUI;

    public void StartCutscene()
    {
        OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = false;
        shaker.CauseShake();
        AudioManager.Instance.Play("OpeningExplosion");
        firstTutorial.GetComponent<Collider>().enabled = true;
        staminaUI.alpha = 1f;
        shaker.onShakeFinish.AddListener(() => {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.GetComponent<PlayerInput>().enabled = true;
            InvokePostPlay();
        });

    }

    public void InvokePostPlay()
    {
        var assemblyTypes = Assembly.GetAssembly(GetType()).GetTypes().Where(type => !type.IsGenericType && typeof(MonoBehaviour).IsAssignableFrom(type));

        foreach (var type in assemblyTypes)
        {
            var instances = FindObjectsOfType(type);
            foreach (var instance in instances)
            {
                var method = type.GetMethod("PostPlay", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(instance, null);
            }
        }
    }
}
