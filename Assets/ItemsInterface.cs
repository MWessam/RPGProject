using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}
public abstract class Item : MonoBehaviour, IInteractable
{
    string _name;
    string _description;
    float _weight;
    float _value;
    public string Name { get => _name; protected set => _name = value; }
    public string Description { get => _description; protected set => _description = value; }
    public float Weight { get => _weight; protected set => _weight = value; }
    public float Value { get => _value; protected set => _value = value; }
    public abstract void Use();
    public virtual void Interact()
    {

    }
    public virtual void Pickup(ref InventoryComponent inventory)
    {
        
    }
    public virtual void Drop()
    {

    }
}
