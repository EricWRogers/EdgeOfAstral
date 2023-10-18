using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturePiece : MonoBehaviour
{
    public struct FractureData
    {
        Vector3 impactDirection;
    }

    [HideInInspector]
    public FractureData fractureData;
}
