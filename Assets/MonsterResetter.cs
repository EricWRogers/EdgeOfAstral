using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterResetter : MonoBehaviour
{
    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
        SaveManager.Instance.onReset.AddListener(() => transform.position = startingPos);
    }

    public void Move()
    {

    }
}
