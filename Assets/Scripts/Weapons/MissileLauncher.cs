using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class MissileLauncher : Weapon {


    public override int GetDamagePerParticle() {
        return weaponConfig.GetDamagePerParticle();
    }

}
