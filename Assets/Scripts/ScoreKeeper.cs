using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    [HideInInspector]
    public bool gameOver = false;
    private int score;
    private Text scoreText;
    private Text gameOverText;

	void Start () {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
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

    public void GameOver() {
        gameOver = true;
        gameOverText.enabled = true;
        gameOverText.text = "GAME OVER \n Score: " + score;
        scoreText.enabled = false;
        //Set UI to say gameover and show score
    }

    public void Restart() {
        //TODO restart game
    }
}
