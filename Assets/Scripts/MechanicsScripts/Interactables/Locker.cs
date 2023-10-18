using OmnicatLabs.Tween;
using UnityEngine;
public class Locker : Interactable
{
    public Transform doorPivot;
    public InventoryItemData unlockItem;
    public bool startInteractable = false;
    public bool useKeypad = false;

    private Quaternion originalOrientation;

    protected override void Start()
    {
        base.Start();

        originalOrientation = transform.rotation;

        if (unlockItem != null)
        {
            SetInteractable(false);
            //unlockItem.onAddToInventory.AddListener(() => { SetInteractable(true); });
        }
        if (!startInteractable)
        {
            SetInteractable(false);
        }
    }

    protected override void OnHover()
    {
        base.OnHover();

        if (unlockItem != null)
            if (InventorySystem.Instance.Get(unlockItem) != null)
            {
                SetInteractable(true);
            }
            else SetInteractable(false);
    }

    public override void OnReset()
    {
        base.OnReset();

        doorPivot.rotation = originalOrientation;
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
