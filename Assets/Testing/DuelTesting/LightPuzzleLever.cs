using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Tween;

public class LightPuzzleLever : Interactable
{
    public Transform leverPivot;
    public float flipTime = .7f;
    //Set lights to toggle in inspector
    public List<GameObject> linkedLights = new List<GameObject>();

    private bool isFlipped = false;


    //changes state of each light
    public override void OnInteract()
    {
        base.OnInteract();

        isFlipped = !isFlipped;

        if (!isFlipped)
        {
            leverPivot.TweenZRot(120f, flipTime);
        }
        else
        {
            leverPivot.TweenZRot(-120f, flipTime);
        }

        for(int i = 0; i < linkedLights.Count; i++)
        {
            linkedLights[i].GetComponent<LightPuzzleLights>().ChangeLightState();
        }
    }

}
