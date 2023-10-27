using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Extensions;

public class Launch : MonoBehaviour
{
    public string playerTag;
    public float launchForce;
    public LayerMask playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponentInParentAndChildren(out Rigidbody rb);

        if (other.CompareTag(playerTag) && rb.velocity.y < 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(new Vector3(0f, launchForce, 0f), ForceMode.Impulse);
        }
    }

    //private float originalJumpForce;

    //private void Start()
    //{
    //    originalJumpForce = OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce;
    //}

    //private void Update()
    //{
    //    if (Physics.CheckBox(new Vector3(col.bounds.center.x, col.bounds.center.y + offset, col.bounds.center.z), col.bounds.extents, Quaternion.identity, playerLayer))
    //    {
    //        if (UpgradeManager.Owns(UpgradeIds.MagBoots))
    //        {
    //            if (!added)
    //            {
    //                OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce *= launchForce;
    //                added = true;
    //                OmnicatLabs.CharacterControllers.CharacterController.Instance.onGrounded.AddListener(() => OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce = originalJumpForce);
    //            }
    //        }
    //        else
    //        {
    //            GetComponent<Dialogue>().TriggerDialogue();
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("exited");
    //        //OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce = originalJumpForce;
    //        added = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (shouldPush)
    //    {
    //        OmnicatLabs.CharacterControllers.CharacterController.Instance.rb.AddForce(new Vector3(0, launchForce, 0), ForceMode.Force);
    //        shouldPush = false;
    //    }
    //}

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.CompareTag(playerTag))
    //    {
    //        if (UpgradeManager.Owns(UpgradeIds.MagBoots))
    //        {
    //            OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce *= launchForce;
    //            OmnicatLabs.CharacterControllers.CharacterController.Instance.onGrounded.AddListener(() => OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce = originalJumpForce);
    //        }
    //        else
    //        {
    //            GetComponent<Dialogue>().TriggerDialogue();
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        Debug.Log("exit");
    //        OmnicatLabs.CharacterControllers.CharacterController.Instance.baseJumpForce = originalJumpForce;
    //    }
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(new Vector3(GetComponent<Collider>().bounds.center.x, GetComponent<Collider>().bounds.center.y +offset, GetComponent<Collider>().bounds.center.z), GetComponent<Collider>().bounds.extents * 2);
    //}

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