using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}

    public void AddScore(int i) {
        score += i;
        print (GetScore());
    }

    public int GetScore() {
        return score;
    }
}
