using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoComponent : MonoBehaviour, IAmmoComponent
{
    [SerializeField] private int _maxMagazineSize;
    [SerializeField] private int _currentMagazine;
    [SerializeField] private int _maxAmmoReserve;
    [SerializeField] private int _currentAmmoReserve;
    public int MaxMagazineSize { get => _maxMagazineSize; set => _maxMagazineSize = value; }
    public int CurrentMagazine { get => _currentMagazine; 
        set 
        {
            if (value < 0 || value > _maxMagazineSize)
            {
                _maxMagazineSize = 0;
            }
            else
            {
                _currentMagazine = value;
            }
        } 
    }
    public int MaxAmmoReserve { get => _maxAmmoReserve; set => _maxAmmoReserve = value; }
    public int CurrentAmmoReserve { get => _currentAmmoReserve; set
        {
            if (value < 0 || value > MaxAmmoReserve)
            {
                _currentAmmoReserve = 0;
            }
            else
            {
                _currentAmmoReserve = value;
            }
        }
        
    }
    private void Start()
    {
        CurrentAmmoReserve = MaxAmmoReserve;
        CurrentMagazine = MaxMagazineSize;
    }
    public void AddAmmo(int ammo)
    {
         CurrentAmmoReserve += ammo;
    }

    public void Reload()
    {
        int tempAmmoVar = CurrentMagazine;
        CurrentMagazine = Mathf.Clamp(CurrentAmmoReserve, 0, MaxMagazineSize);
        CurrentAmmoReserve -= tempAmmoVar;
    }
    public void ShotBullet()
    {
        CurrentMagazine--;
    }
}
