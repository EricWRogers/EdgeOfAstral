using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturePieceScript : MonoBehaviour
{
    private GameObject DestructableWallFragments;

    void Awake()
    {
       
    }

     public void FracturePieces(Collider col, GameObject obj, Vector3 vec)
    {
        DestructableWallFragments = GameObject.Find("DestructableWallFragments");

        //int FracturePieceLayer = LayerMask.NameToLayer("FracturePiece");
        //DestructableWallFragments.layer = FracturePieceLayer;

        Debug.Log((col, obj, vec));
    }
}
