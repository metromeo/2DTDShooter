using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : MonoBehaviour {
    [SerializeField] protected ParticleSystem ps;

    protected float nextFireTime;
    [SerializeField] protected bool isReloading;
    [SerializeField] protected int currentAmmoInMagazine;

    protected ParticleSystem.Particle[] particles;

    protected bool CanFire() => Time.time >= nextFireTime && !isReloading;
	public abstract void TryShoot(Vector3 mouseWorldPos);
    public abstract void MakeShoot(Vector3 mouseWorldPos);
    public abstract void Reload();
    public abstract void ParticleHit();
}
