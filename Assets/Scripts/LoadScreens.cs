using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreens : MonoBehaviour
{
    public string ResetGame; //for the restart game button

    private void OnTriggerEnter3D(Collider other)
    {
        if (this.gameObject.tag == "PlayerDed") //if player's dead
        {
                SceneManager.LoadScene(GameOver, LoadSceneMode.Single); //send to game over screen
        }
        else if (this.gameObject.tag == "PlayerWin") //if player escapes
        {
            SceneManager.LoadScene(YouWin, LoadSceneMode.Single); //send to winner screen
        }    
    }

    public void RestartGame(string sceneName)
    {
        PlayerChar.State.Restart();
        SceneManager.LoadScene(sceneName); //set this to the next checkpoint wherever it is
    }
}
