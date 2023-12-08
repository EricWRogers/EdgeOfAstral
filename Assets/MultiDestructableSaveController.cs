using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiDestructableSaveController : MonoBehaviour, ISaveable
{
    private List<GameObject> rubbleObjs = new List<GameObject>();
    private void Start()
    {
        rubbleObjs = GetComponentsInChildren<GameObject>().ToList();
        rubbleObjs.Remove(gameObject);
        rubbleObjs.ForEach(obj => GetComponent<Fracture>().callbackOptions.onFracture.AddListener((col, obj, vec) => SaveManager.Instance.Track(this)));
    }

    public void OnReset()
    {
        rubbleObjs.ForEach(obj => obj.SetActive(true));
    }

    public void OnTrack()
    {

    }
}
