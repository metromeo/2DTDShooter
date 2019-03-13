using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField] private MovementConfig movementCfg;
    


    private Transform me;
    

    private void Awake() {
        me = transform;
        Subscribe();
    }


    private void OnDestroy() {
        UnSubscribe();
    }

    void Subscribe() {
        PlayerInputInterpretator.OnMove += Move;
        PlayerInputInterpretator.OnRotate += Rotate;
    }
    void UnSubscribe() {
        PlayerInputInterpretator.OnMove -= Move;
        PlayerInputInterpretator.OnRotate -= Rotate;
    }

    void Move(float hor, float ver) {
        me.position += new Vector3(hor, 0, ver) * Time.deltaTime * movementCfg.GetMovementSpeed();
        PlayerEvents.PlayerMoving(me.position);
    }

    void Rotate(Vector3 mouseWorldPos) {
        me.LookAt(mouseWorldPos);
    }

	
}
