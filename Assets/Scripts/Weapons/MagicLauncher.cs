using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class PathSection {
    public Vector3 point;
    public Vector3 Point { get; private set; }
    public PathSection(Vector3 p) {
        Point = p;
        point = p;
    }
}
[System.Serializable]
public class MagicLauncherProjectilePath {
    //[SerializeField] private List<PathSection> path;
    public Vector3 TargetPoint { get; set; }
    //public bool IsFree { get; private set;}
    [SerializeField] public Vector3 CurrentPosition;
    //private int currPathSectionIndex;
    public uint particleSeed;

    public MagicLauncherProjectilePath(Vector3 endP) {
        //IsFree = false;
        //currPathSectionIndex = 0;
        TargetPoint = endP;
        //path = new List<PathSection>();
        //path.Add(new PathSection(endP));
    }

    //public void SetFree() {
    //    IsFree = true;
    //}

    //public Vector3 GetNextPoint(Vector3 currPoint) {
    //    if (Vector3.Distance(currPoint, path[currPathSectionIndex].Point) < 0.1f) {
    //        if (currPathSectionIndex + 1 < path.Count)
    //            currPathSectionIndex++;
    //    } 
    //    return path[currPathSectionIndex].Point;
    //}


}

public class MagicLauncher : Weapon {
    [SerializeField] private WeaponConfig weaponConfig;
    [SerializeField] private List<MagicLauncherProjectilePath> paths;

    private Transform me;
    private float missileSpeed = 2f;


    private void Awake() {
        me = transform;
        currentAmmoInMagazine = weaponConfig.GetMagazineCapacity();
        particles = new ParticleSystem.Particle[5];
        paths = new List<MagicLauncherProjectilePath>();
        var main = ps.main;
        main.startSpeed = weaponConfig.GetProjectileSpeed();
    }

    public override void TryShoot(Vector3 mouseWorldPos) {
        if (CanFire()) {
            MakeShoot(mouseWorldPos);
        }
    }

    public override void MakeShoot(Vector3 mouseWorldPos) {
        nextFireTime = Time.time + weaponConfig.GetFireRate();

        ps.Emit(weaponConfig.GetParticlesPerShot());

        CreateNewPath(mouseWorldPos);

        currentAmmoInMagazine--;
        if (currentAmmoInMagazine <= 0) {
            isReloading = true;
            Reload();
        }
    }

    public override async void Reload() {
        await Task.Delay(weaponConfig.GetReloadTime());
        currentAmmoInMagazine = weaponConfig.GetMagazineCapacity();
        isReloading = false;
    }

    private void Update() {

        int pNum = ps.GetParticles(particles);
        for (int i = 0; i < pNum; i++) {
            Debug.Log("control particle " + i);
            int j = -1;
            for (int s = 0; s < paths.Count; s++) {
                if (paths[s].particleSeed == particles[i].randomSeed) {
                    j = s;
                    break;
                }
            }
            if (j == -1) continue;
            if (i >= paths.Count || paths[j] == null) continue;
            //Debug.Log("Part seed = " + particles[i].randomSeed);
            //Debug.Log("paths seed = " + paths[j].particleSeed);
            Debug.Log("TV = " + particles[i].totalVelocity);
            Debug.Log("distance = " + Vector3.Distance(particles[i].position, paths[j].TargetPoint));
            if (Vector3.Distance(particles[i].position, paths[j].TargetPoint) <= 5f){
                particles[i].velocity = -particles[i].animatedVelocity;
                
                //Debug.Log("INC = " + (paths[j].TargetPoint - particles[i].position).normalized);
                particles[i].position += (paths[j].TargetPoint - particles[i].position).normalized
                                        * Time.deltaTime * weaponConfig.GetProjectileSpeed();



            } else {
                var main = ps.main;
                main.startSpeed = weaponConfig.GetProjectileSpeed();
            }
        }
        ps.SetParticles(particles, pNum);
    }

    public override void ParticleHit(){
        if (paths.Count > 0){
            paths.RemoveAt(0);
        }
    }

    void CreateNewPath(Vector3 targetPos) {
        paths.Add(new MagicLauncherProjectilePath(targetPos));

        int pNum = ps.GetParticles(particles);
        uint seed = 0;
        for (int i = pNum - 1; i >= 0; i--){
            if (particles[i].randomSeed != 0){
                seed = particles[i].randomSeed;
                break;
            }
        }
        paths[paths.Count - 1].particleSeed = seed;
    }

}
