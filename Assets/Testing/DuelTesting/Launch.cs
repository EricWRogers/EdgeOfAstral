using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public string playerTag;
    public float launchForce;
    public float offset = 1f;
    public LayerMask playerLayer;

    private Collider col;
    private bool shouldPush = false;
    private float originalJumpForce;
    private bool added = false;

    private void Start()
    {
        col = GetComponent<Collider>();
        originalJumpForce = OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce;
    }

    private void Update()
    {
        if (Physics.CheckBox(new Vector3(col.bounds.center.x, col.bounds.center.y + offset, col.bounds.center.z), col.bounds.extents, Quaternion.identity, playerLayer))
        {
            if (UpgradeManager.Owns(UpgradeIds.MagBoots))
            {
                if (!added)
                {
                    OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce *= launchForce;
                    added = true;
                }
            }
            else
            {
                GetComponent<Dialogue>().TriggerDialogue();
            }
        }
        else
        {
            OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce = originalJumpForce;
            added = false;
        }
    }

    //private void FixedUpdate()
    //{
    //    if (shouldPush)
    //    {
    //        OmnicatLabs.CharacterControllers.CharacterController.Instance.rb.AddForce(new Vector3(0, launchForce, 0), ForceMode.Force);
    //        shouldPush = false;
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        //col.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, launchForce, 0), ForceMode.Force);

        //if(col.CompareTag(playerTag))
        //{
        //    if (UpgradeManager.Owns(UpgradeIds.MagBoots))
        //    {
        //        col.GetComponent<Rigidbody>().AddForce(new Vector3(0, launchForce, 0), ForceMode.Force);
        //    }
        //    else
        //    {
        //        GetComponent<Dialogue>().TriggerDialogue();
        //    }
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(GetComponent<Collider>().bounds.center.x, GetComponent<Collider>().bounds.center.y +offset, GetComponent<Collider>().bounds.center.z), GetComponent<Collider>().bounds.extents * 2);
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