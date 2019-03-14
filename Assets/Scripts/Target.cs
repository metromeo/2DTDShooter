using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IHaveHealth, IHaveScores {
    [SerializeField] private int health;
    public int Health {
        get { return health; }
        set { health = value; }
    }
    [SerializeField] private int score;
    public int Score {
        get { return score; }
        set { score = value; }
    }

    public void ModifyHealth(int amount) {
        Health -= amount;
        if (Health <= 0) {
            OnDeath();
        }
    }

    void OnDeath() {
        Score_Controller.AddScore(score);
        Destroy(gameObject);
    }
}
