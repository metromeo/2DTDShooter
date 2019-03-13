using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New movement config", menuName = "Configs/Create movement config")]
public class MovementConfig : ScriptableObject {

	[SerializeField] private float movementSpeed = 1f;


    public float GetMovementSpeed() => movementSpeed;


}
