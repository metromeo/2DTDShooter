using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsControl : MonoBehaviour {
    [SerializeField] private Weapon leftWeaponPrefab;
    [SerializeField] private Weapon rightWeaponPrefab;
    [SerializeField] private Transform leftWeaponParent;
    [SerializeField] private Transform rightWeaponParent;

    private Weapon leftWeapon;
    private Weapon rightWeapon;

    private void Awake() {
        Subscribe();
        InstantiateWeapons();
    }

    private void OnDestroy() {
        UnSubscribe();
    }

    void InstantiateWeapons() {
        GameObject w = Instantiate(leftWeaponPrefab.gameObject, leftWeaponParent);
        leftWeapon = w.GetComponent<Weapon>();

        w = Instantiate(rightWeaponPrefab.gameObject, rightWeaponParent);
        rightWeapon = w.GetComponent<Weapon>();
    }

    void Subscribe() {
        PlayerInputInterpretator.OnLeftMouseDown += ShootLeft;
        PlayerInputInterpretator.OnRightMouseDown += ShootRight;
    }
    void UnSubscribe() {
        PlayerInputInterpretator.OnLeftMouseDown -= ShootLeft;
        PlayerInputInterpretator.OnRightMouseDown -= ShootRight;
    }

    void ShootLeft() {
        leftWeapon.TryShoot();
    }
    void ShootRight() {
        rightWeapon.TryShoot();
    }

}
