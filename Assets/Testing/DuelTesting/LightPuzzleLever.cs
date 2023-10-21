using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Tween;

public class LightPuzzleLever : Interactable
{
    public Transform leverPivot;
    public float flipTime = .7f;
    public Material wireOnMaterial;
    //Set lights to toggle in inspector
    public List<GameObject> linkedLights = new List<GameObject>();
    public List<GameObject> wires = new List<GameObject>();

    private bool isFlipped = false;
    private Material wireOffMaterial;


    protected override void Start()
    {
        base.Start();
        if (wires.Count > 0)
        wireOffMaterial = wires[0].GetComponent<MeshRenderer>().material;
    }

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

        foreach (var wire in wires)
        {
            if (isFlipped)
            {
                wire.GetComponent<MeshRenderer>().material = wireOnMaterial;
            }
            else
            {
                wire.GetComponent<MeshRenderer>().material = wireOffMaterial;
            }
        }
    }

}
