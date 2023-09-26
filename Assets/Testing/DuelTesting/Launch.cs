using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public string playerTag;
    public float launchForce;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, launchForce, 0));
        }
    }

    // Commented out code is designed to work when attached to the player; unused
    /*
    private Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "launchpad":
                rb.AddForce(new Vector3(0, launchForce, 0));
                break;
        }
    }
    */
}