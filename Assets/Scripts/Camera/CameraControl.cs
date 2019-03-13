using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Camera cam;

    void Awake() {
        Referencer.Add(typeof(CameraControl), this);
        cam = GetComponent<Camera>();
    }

    public Camera GetCamera() => cam;

}
