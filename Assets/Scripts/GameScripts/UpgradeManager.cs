using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static List<UpgradeIds> ownedUpgrades = new List<UpgradeIds>();

    public static void AddToOwned(UpgradeIds upgrade)
    {
        ownedUpgrades.Add(upgrade);
    }

    public static bool Owns(UpgradeIds upgradeToQuery)
    {
        return ownedUpgrades.Contains(upgradeToQuery);
    }
}
