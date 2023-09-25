using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : Interactable
{
    public enum UpgradeIds
    {
        MagBoots = 1,
        WallRunning = 2,
        Grapple = 3,
        DoubleJump = 4,
        LightningGun = 5
    };
    public override void OnInteract()
    {
        base.OnInteract();
        
    }
}
