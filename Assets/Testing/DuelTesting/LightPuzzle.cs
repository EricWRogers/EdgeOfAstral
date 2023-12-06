using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OmnicatLabs.Timers;

public class LightPuzzle : MonoBehaviour
{
    public float winWaitTime = 1f;
    public Material wireOnMaterial;
    private Material wireOffMaterial;
    public List<GameObject> LightObjects = new List<GameObject>();
    public List<GameObject> finalWires = new List<GameObject>();
    public UnityEvent LightPuzzleCompleted = new UnityEvent();

    public static LightPuzzle Instance;
    private Timer timer;
    public static bool isCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        wireOffMaterial = finalWires[0].GetComponent<MeshRenderer>().material;
    }

    public void CheckPuzzleWin()
    {
        if (timer != null)
        {
            //if a timer is active from an old configuration cancel it and start a new one
            TimerManager.Instance.Stop(timer);
            TimerManager.Instance.CreateTimer(winWaitTime, Win, out timer);
        }
        else
        {
            TimerManager.Instance.CreateTimer(winWaitTime, Win, out timer);
        }
    }

    private void Win()
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
            foreach (var wire in finalWires)
            {
                wire.GetComponent<MeshRenderer>().material = wireOnMaterial;
            }
            isCompleted = true;
        }
    }
}
