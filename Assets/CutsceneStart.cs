using UnityEngine;
using UnityEngine.Playables;
using OmnicatLabs.Audio;
using UnityEngine.Events;

public class CutsceneStart : MonoBehaviour
{
    public UnityEvent onFinish = new UnityEvent();
    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = OmnicatLabs.CharacterControllers.CharacterController.Instance;
            controller.SetControllerLocked(true, true, true);
            controller.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
            controller.camHolder.transform.localRotation = Quaternion.identity;
            FindObjectOfType<PlayableDirector>().Play();
            started = true;
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PlayableDirector>().state != PlayState.Playing && started)
        {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
            AudioManager.Instance.Play("BGM");
            if (TryGetComponent(out ChangeObjective changeObjective))
            {
                changeObjective.Change();
            }
            if (TryGetComponent(out Dialogue dialogue))
            {
                dialogue.TriggerDialogue();
            }
            onFinish.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
