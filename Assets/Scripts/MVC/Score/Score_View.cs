using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_View : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI tmpro;

    private void Awake() {
        Score_Controller.OnScoreUpdate += UpdateScore;
    }

    void UpdateScore(int v) {
        tmpro.text = v.ToString();
    }

}
