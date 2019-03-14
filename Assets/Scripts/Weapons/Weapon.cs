using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Weapon : MonoBehaviour {
    [SerializeField] protected WeaponConfig weaponConfig;
    [SerializeField] protected ParticleSystem ps;

    protected float nextFireTime;
    protected bool isReloading;
    protected int currentAmmoInMagazine;

    protected ParticleSystem.Particle[] particles;

    private void Awake() {
        currentAmmoInMagazine = weaponConfig.GetMagazineCapacity();
        particles = new ParticleSystem.Particle[weaponConfig.GetMagazineCapacity() * 2];
        var main = ps.main;
        main.startSpeed = weaponConfig.GetProjectileSpeed();
    }

    protected bool CanFire() => Time.time >= nextFireTime && !isReloading;
    public virtual void TryShoot() {
        if (CanFire()) {
            MakeShoot();
        }
    }
    public virtual void MakeShoot() {
        nextFireTime = Time.time + weaponConfig.GetFireRate();
        ps.Emit(weaponConfig.GetParticlesPerShot());
        currentAmmoInMagazine--;
        if (currentAmmoInMagazine <= 0) {
            Reload();
        }
    }
    public virtual async Task Reload() {
        isReloading = true;
        await Task.Delay(weaponConfig.GetReloadTime());
        currentAmmoInMagazine = weaponConfig.GetMagazineCapacity();
        isReloading = false;
    }

    public abstract int GetDamagePerParticle();
}
