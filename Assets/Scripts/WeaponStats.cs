﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField]
    private string _weaponName = "Weapon Name";
    public string WeaponName {
        get => _weaponName;
    }

    [SerializeField]
    private int _damage = 1;
    public int Damage
    {
        get => _damage;
    }

    [SerializeField]
    private float _fireRate = 666f; // RPM
    public float FireRate
    {
        get => _fireRate;
    }

    [SerializeField]
    private int _magSize = 30;
    public int MagSize
    {
        get => _magSize;
    }

    [SerializeField]
    private int _reserveAmmoCapacity = 90;
    public int ReserveAmmoCapacity
    {
        get => _reserveAmmoCapacity;
    }

    [SerializeField]
    private float _reloadTime = 1.8f;
    public float ReloadTime
    {
        get => _reloadTime;
    }

    [SerializeField]
    private float _effectiveRange = 500f;
    public float EffectiveRange
    {
        get => _effectiveRange;
    }

    [SerializeField]
    private float _impForce = 300f;
    public float ImpactForce
    {
        get => _impForce;
    }

    [SerializeField]
    private bool _isAutomatic = false;
    public bool IsAutomatic
    {
        get => _isAutomatic;
    }

    [SerializeField]
    private bool _isADS = true;
    public bool IsADS
    {
        get => _isADS;
    }

    [SerializeField]
    private float recoilSpeed = 0.1f;
    public float RecoilSpeed
    {
        get => recoilSpeed;
    }

    [SerializeField]
    private float recoilDecay = 1f;
    public float RecoilDecay
    {
        get => recoilDecay;
    }

    [SerializeField]
    private float recoilScale = 1f;
    public float RecoilScale
    {
        get => recoilScale;
    }

    [SerializeField]
    private float bulletSpread = 0.5f;
    public float BulletSpread
    {
        get => bulletSpread;
    }

    private float maxRecoil = 1f;
    public float MaxRecoil
    {
        get => maxRecoil;
    }

    // runtime states
    public bool isReloading = false;
    public bool isSwapping = false;
    public int currentAmmo;
    public int reserveAmmo = 0;
    public float nextFireTime = 0;
    public float currentRecoil = 0;

    private void Awake()
    {
        currentAmmo = _magSize;
    }
    private void OnEnable()
    {
        isReloading = false;
        nextFireTime = 0;
        currentRecoil = 0;
    }
}
