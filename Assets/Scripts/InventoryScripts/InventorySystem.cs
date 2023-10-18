using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public static InventorySystem Instance;

    public List<InventoryItem> inventory { get; private set; }

    private List<InventoryItem> savedInventory = new List<InventoryItem>();
    private Dictionary<InventoryItemData, InventoryItem> savedDictionary = new Dictionary<InventoryItemData, InventoryItem>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        inventory = new List<InventoryItem>();
        SaveManager.Instance.onReset.AddListener(ResetInventory);
        SaveManager.Instance.onSave.AddListener(SaveInventory);
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public InventoryItem Get(string name)
    {
        var item = inventory.Find(item => item.data.displayName == name);
        if (item != null)
        if (m_itemDictionary.TryGetValue(item.data, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        referenceData.onAddToInventory.Invoke();

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

    public void Clear()
    {
        inventory.Clear();
        m_itemDictionary.Clear();
    }

    private void ResetInventory()
    {
        inventory.Clear();
        m_itemDictionary.Clear();

        foreach ((var key, var value) in savedDictionary)
        {
            m_itemDictionary.Add(key, value);
        }
        inventory.AddRange(savedInventory);

        Debug.Log(inventory.Count);
    }

    private void SaveInventory()
    {
        savedInventory.Clear();
        savedDictionary.Clear();

        foreach ((var key, var value) in m_itemDictionary)
        {
            savedDictionary.Add(key, value);
        }
        savedInventory.AddRange(inventory);
    }
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