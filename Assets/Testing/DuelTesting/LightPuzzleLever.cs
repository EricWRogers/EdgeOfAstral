using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleLever : Interactable
{
    public List<GameObject> linkedLights = new List<GameObject>();

    private bool isFlipped = false;

    public override void OnInteract()
    {
        base.OnInteract();

        isFlipped = !isFlipped;

        for(int i = 0; i < linkedLights.Count; i++)
        {
            linkedLights[i].GetComponent<LightPuzzleController>().ChangeLightState();
        }
    }
}
