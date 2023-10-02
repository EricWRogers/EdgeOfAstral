using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class ToggleOfflink : MonoBehaviour 
{ 
 
    public GameObject toggle; 
    // Start is called before the first frame update 
    void Start() 
    { 
       gameObject.GetComponent<UnityEngine.AI.OffMeshLink>().activated = false; 
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        if(toggle == null) 
        { 
            gameObject.GetComponent<UnityEngine.AI.OffMeshLink>().activated = true; 
        } 
    } 
} 
