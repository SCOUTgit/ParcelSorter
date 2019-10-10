using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBoard : MonoBehaviour {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button goMainButton;

    public void SetGameOverBoard(int score) {
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {PlayerPrefs.GetInt("BestScore")}";
        restartButton.onClick.AddListener(()=>SceneManager.LoadScene("GameScene"));
        goMainButton.onClick.AddListener(()=>SceneManager.LoadScene("MainScene"));
    }
}