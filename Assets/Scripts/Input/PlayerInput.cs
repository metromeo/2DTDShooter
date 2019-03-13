using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour {
    private Camera cam;
    [SerializeField] private LayerMask mouseHitOverMask;

    private void Start() {
        cam = Referencer.Get<CameraControl>().GetCamera();
    }

    private void Update() {
        ReadAxis();
        ReadMouse();
    }

    void ReadAxis() {
        PlayerInputInterpretator.Move(Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical"));
    }

    void ReadMouse() {
        if (EventSystem.current.IsPointerOverGameObject())    // is the touch on the GUI
        {
            Debug.Log("UI");
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 mouseWorldPos = Vector3.zero;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseHitOverMask)) {
            mouseWorldPos = hit.point;
        }
        PlayerInputInterpretator.Rotate(mouseWorldPos);
        if (Input.GetMouseButton(0)) {
            PlayerInputInterpretator.LeftMouseDown(mouseWorldPos);
        }
        if (Input.GetMouseButton(1)) {
            PlayerInputInterpretator.RightMouseDown(mouseWorldPos);
        }
    }
}
