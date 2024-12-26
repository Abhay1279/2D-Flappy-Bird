using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreWindow : MonoBehaviour {

    private TextMeshProUGUI highscoreText;
    private TextMeshProUGUI scoreText;

    private void Awake() {
        scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        highscoreText = transform.Find("highscoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();
        Bird.GetInstance().OnDied += ScoreWindow_OnDied;
        Bird.GetInstance().OnStartedPlaying += ScoreWindow_OnStartedPlaying;
        Hide();
    }

    private void ScoreWindow_OnStartedPlaying(object sender, System.EventArgs e) {
        Show();
    }

    private void ScoreWindow_OnDied(object sender, System.EventArgs e) {
        Hide();
    }

    private void Update() {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

}
