using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private MovementConfig movementCfg;
	private Transform me;
    private Vector3 camOffset;
    private Vector3 targetPos;


    void Awake() {
        me = transform;
        camOffset = me.position;
        Subsribe();
    }
    ~CameraFollow() {
        UnSubsribe();
    }

    void Subsribe() {
        PlayerEvents.OnMove += TargetMoving;
    }

    void UnSubsribe() {
        PlayerEvents.OnMove -= TargetMoving;
    }

    void LateUpdate() {
        me.position = Vector3.Lerp(me.position, 
                                    targetPos + camOffset, 
                                    Time.deltaTime * movementCfg.GetMovementSpeed());
    }

    void TargetMoving(Vector3 targetPos) {
        this.targetPos = targetPos;
    }
}
