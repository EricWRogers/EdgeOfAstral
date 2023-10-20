using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    private GameObject Player;
    private GameObject Spawnpoint;
    public GameObject LoseUI;

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Retry()
    {
        Player = GameObject.Find("Player");
        //Spawnpoint = GameObject.Find("Spawnpoint");
        LoseUI.SetActive(false);
        OmnicatLabs.CharacterControllers.CharacterController.Instance.SetControllerLocked(false, false, false);
        OmnicatLabs.CharacterControllers.CharacterController.Instance.rb.velocity = Vector3.zero;
        SaveManager.Instance.ResetTracked();
        OmnicatLabs.CharacterControllers.CharacterController.Instance.transform.position = Checkpoint.spawnpoint.position;
        //Player.transform.position = Spawnpoint.transform.position;

    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
