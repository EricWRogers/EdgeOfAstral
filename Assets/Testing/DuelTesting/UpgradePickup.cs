using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : Interactable
{
    public enum UpgradeIds
    {
        MagBoots = 0,
        WallRunning = 1,
        Grapple = 2,
        DoubleJump = 3,
        LightningGun = 4
    }

    public UpgradeIds UpgradeID;

    public override void OnInteract()
    {
        base.OnInteract();

        switch (UpgradeID)
        {
            case UpgradeIds.MagBoots:
                break;
            case UpgradeIds.WallRunning:
                break;
            case UpgradeIds.Grapple:
                break;
            case UpgradeIds.DoubleJump:
                break;
            case UpgradeIds.LightningGun:
                break;

        }
    }
}