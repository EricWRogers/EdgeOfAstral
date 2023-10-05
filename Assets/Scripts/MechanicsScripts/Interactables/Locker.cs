using OmnicatLabs.Tween;
using UnityEngine;
public class Locker : Interactable
{
    public Transform doorPivot;
    public InventoryItemData unlockItem;
    public bool startInteractable = false;
    public bool useKeypad = false;

    protected override void Start()
    {
        base.Start();

        if (unlockItem != null)
        {
            SetInteractable(false);
            unlockItem.onAddToInventory.AddListener(() => { SetInteractable(true); });
        }
        if (!startInteractable)
        {
            SetInteractable(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (unlockItem == null)
        {
            doorPivot.TweenYRot(60f, 2f);

            SetInteractable(false);
        }
        else
        {
            if (InventorySystem.Instance.Get(unlockItem) != null)
            {
                doorPivot.TweenYRot(60f, 2f);

                SetInteractable(false);
            }
        }



    }
}
