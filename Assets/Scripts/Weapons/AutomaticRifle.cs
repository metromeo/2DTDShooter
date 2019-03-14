using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRifle : Weapon {

    public override int GetDamagePerParticle() {
        return weaponConfig.GetDamagePerParticle();
    }
}
