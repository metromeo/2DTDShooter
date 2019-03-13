using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvents  {

	public static event Action<Vector3> OnMove = delegate { };

    public static void PlayerMoving(Vector3 pos) {
        OnMove(pos);
    }
}
