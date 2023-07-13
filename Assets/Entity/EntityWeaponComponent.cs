using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWeaponComponent : MonoBehaviour, IWeaponComponent
{
    [SerializeField] private Weapon _weapon;
    public IWeapon Weapon { get => _weapon;}

    // Start is called before the first frame update
    void Start()
    {
    }
}
