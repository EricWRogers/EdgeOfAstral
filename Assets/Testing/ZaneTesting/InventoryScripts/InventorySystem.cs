using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;

    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

  /*  void Update()
    {
        if (!useLookAt)
        {
            _targetPosition = _parent.position + _parent.forward = 2f + new Vector3(0f, 2f, 0f);
        }

        _lookAtTarget.transform.position = Vector3.Lerp(_lookAtTarget.transform.position, _targetPosition, Time.deltaTime * lookSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_lookAtTarget != null && _lookAtTarget.TryGetComponent<ItemObject>(out ItemObject item))
            {
                item.OnHandlePickupItem();
                itemController.SetTargetPosition(item.transform);
                itemController.Pickup();
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<PointOfInterest>())
        {
            _targetPosition = collider.transform.position;
            useLookAt = true;
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        useLookAt = false;
    } */
}
[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}

public class ItemObject : MonoBehaviour //handles the pickup for each item
{
    public InventoryItem referenceItem;

    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem); //singleton reference to inventory manager
        Destroy(gameObject);
    }
}