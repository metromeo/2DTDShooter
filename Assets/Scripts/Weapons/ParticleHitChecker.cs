using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHitChecker : MonoBehaviour {

    [SerializeField] private ParticleSystem part;
    [SerializeField] private Weapon weapon;
    private List<ParticleCollisionEvent> collisionEvents;

    private void Awake() {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        IHaveHealth target = other.transform.parent.GetComponent<IHaveHealth>();
        target?.ModifyHealth(numCollisionEvents * weapon.GetDamagePerParticle());
    }
}
