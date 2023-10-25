using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    private GameObject Spawnpoint;
    public GameObject LoseUI;

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Retry()
    {
        var player = OmnicatLabs.CharacterControllers.CharacterController.Instance;
        //Spawnpoint = GameObject.Find("Spawnpoint");
        LoseUI.SetActive(false);
        player.SetControllerLocked(false, false, false);
        player.rb.velocity = Vector3.zero;
        //better fix this later
        player.modelCollider.height = 2f;
        player.camHolder.localPosition = new Vector3(player.camHolder.localPosition.x, player.originalHeight, player.camHolder.localPosition.z);
        player.ChangeState(OmnicatLabs.CharacterControllers.CharacterStates.Idle);
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
