using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score_Controller {
    public static event Action<int> OnScoreUpdate = delegate { };
    public static event Action<int> OnScoreAdd = delegate { };

    public static void UpdateScore(int v) {
        OnScoreUpdate(v);
    }

	public static void AddScore(int v) {
        OnScoreAdd(v);
    }
}

