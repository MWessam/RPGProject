using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IInventoryComponent
{
    public event Action OnPickup;
    public event Action OnDrop;

    [SerializeField] int _maxWeight;
    [SerializeField] float _currentWeight;
    List<Item> _items = new();
    public List<Item> Items { get { return _items; } }
    private void Start()
    {
        
    }
    public void AddItem(ref Item item)
    {
        _items.Add(item);
        _currentWeight += item.Weight;
    }
}
