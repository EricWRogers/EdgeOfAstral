using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightPuzzle : MonoBehaviour
{
    public List<GameObject> LightObjects = new List<GameObject>();
    public UnityEvent LightPuzzleCompleted = new UnityEvent();

    public void CheckPuzzleWin()
    {
        bool puzzleCompleted = true;

        for (int i = 0; i < LightObjects.Count; i++)
        {
            if (LightObjects[i].GetComponent<LightPuzzleLights>().lit == false)
            {
                puzzleCompleted = false;
            }
        }

        if (puzzleCompleted == true)
        {
            LightPuzzleCompleted.Invoke();
        }
    }
}
