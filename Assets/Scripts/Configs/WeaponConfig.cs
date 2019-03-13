using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon config", menuName = "Configs/Create new Weapon config")]
public class WeaponConfig : ScriptableObject {
    //[SerializeField] private WeaponType weaponType;
    //[SerializeField] private Material bulletMaterial;

    [SerializeField] private int magazineCapacity;
    [SerializeField] private int reloadTime; //ms
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int particlesPerShot;
    [SerializeField] private int damagePerParticle;


    //public WeaponType   GetWeaponType()         => weaponType;
    //public Material     GetMaterial()           => bulletMaterial;
    public int          GetMagazineCapacity()   => magazineCapacity;
    public int          GetReloadTime()         => reloadTime;
    public float        GetFireRate()           => fireRate;
    public float        GetProjectileSpeed()        => bulletSpeed;
    public int          GetParticlesPerShot()   => particlesPerShot;
    public int          GetDamagePerParticle()  => damagePerParticle;

}
