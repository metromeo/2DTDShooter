using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Model : MonoBehaviour {

	private int score;

    private void Awake() {
        Score_Controller.OnScoreAdd += AddScore;
    }

    public void AddScore(int amount) {
        score += amount;
        Score_Controller.UpdateScore(score);
    }
}
