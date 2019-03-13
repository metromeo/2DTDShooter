using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputInterpretator  {

    public static event Action<float, float> OnMove = delegate { };
    public static event Action<Vector3> OnRotate = delegate { };
    public static event Action<Vector3> OnLeftMouseDown = delegate { };
    public static event Action<Vector3> OnRightMouseDown = delegate { };


    public static void Move(float hor, float ver) {
        OnMove(hor, ver);
    }

    public static void Rotate(Vector3 mouseWorldPos) {
        OnRotate(mouseWorldPos);
    }

    public static void LeftMouseDown(Vector3 mouseWorldPos) {
        OnLeftMouseDown(mouseWorldPos);
    }

    public static void RightMouseDown(Vector3 mouseWorldPos) {
        OnRightMouseDown(mouseWorldPos);
    }
	
}
