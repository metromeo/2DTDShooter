using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PathSection {
    public Vector3 Point { get; private set; }
    public float Speed { get; private set; }
    public PathSection(Vector3 p, float s) {
        Point = p;
        Speed = s;
    }
}

public class MagicLauncherProjectilePath {
    private List<PathSection> path;
    public bool IsFree { get; private set;}
    private int currPathSectionIndex;

    public MagicLauncherProjectilePath(Vector3 endP, Vector3 start) {
        IsFree = false;
        currPathSectionIndex = 0;
        path = new List<PathSection>();
        path.Add(new PathSection(new Vector3(start.x, start.y + 7f, start.z), 7f));
        path.Add(new PathSection(endP, 20f));
    }

    public void SetFree() {
        IsFree = true;
    }

    public Vector3 GetNextPoint(Vector3 currPoint) {
        if (Vector3.Distance(currPoint, path[currPathSectionIndex].Point) < 0.1f) {
            if (currPathSectionIndex + 1 < path.Count)
                currPathSectionIndex++;
        } 
        return path[currPathSectionIndex].Point;
    }

    public float GetCurrSpeed() {
        return path[currPathSectionIndex].Speed;
    }

}

public class MagicLauncher : Weapon {
    [SerializeField] private WeaponConfig weaponConfig;
    [SerializeField] private MagicLauncherProjectilePath[] paths;

    private Transform me;



    private void Awake() {
        me = transform;
        particles = new ParticleSystem.Particle[5];
        paths = new MagicLauncherProjectilePath[5];
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
            Reload();
        }
    }

    public override async void Reload() {
        isReloading = true;
        await Task.Delay(weaponConfig.GetReloadTime());
        isReloading = false;
    }

    private void Update() {
        int pNum = ps.GetParticles(particles);
        for (int i = 0; i < particles.Length; i++) {
            if (paths[i] == null) continue;
            //Debug.Log("control particle " + i);
            particles[i].position += (paths[i].GetNextPoint(particles[i].position) - particles[i].position).normalized
                                        * Time.deltaTime * paths[i].GetCurrSpeed();


            //particles[i].position = Vector3.Lerp(particles[i].position,
            //                                    paths[i].GetNextPoint(particles[i].position), 
            //                                    Time.deltaTime * paths[i].GetCurrSpeed());
            //Debug.Log("PPos = " + particles[i].position);
        }
        ps.SetParticles(particles, pNum);
    }

    void CreateNewPath(Vector3 targetPos) {
        int pid = GetFirstFreePathID();
        Debug.Log(pid);
        paths[pid] = new MagicLauncherProjectilePath(targetPos,
                                                     new Vector3(me.position.x, 0, me.position.z));

    }

    int GetFirstFreePathID() {
        for (int i = 0; i < paths.Length; i++) {
            if (paths[i] == null || paths[i].IsFree) return i;
        }
        return -1;
    }


}
