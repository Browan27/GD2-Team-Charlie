using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private int score;
    private Text scoreText;

	void Start () {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScoreText();

    }

    public void AddScore(int i) {
        score += i;
        UpdateScoreText();
    }

    public int GetScore() {
        return score;
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }
}
