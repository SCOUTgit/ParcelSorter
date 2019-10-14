using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBoard : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button goMainButton;
    [SerializeField]
    private Text newBestScoreText;

    public void SetGameOverBoard(int score)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (score > bestScore){
            bestScore = score;
            StartCoroutine(NewBestScore());
            PlayerPrefs.SetInt("BestScore", score);
        }

        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
        restartButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
        goMainButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }

    private IEnumerator NewBestScore()
    {
        WaitForSeconds wait = new WaitForSeconds(0.02f);

        newBestScoreText.text = "New!!";
        
        Queue<Color> colorQ = new Queue<Color>();
        colorQ.Enqueue(new Color(0, 0.1f, 0));
        colorQ.Enqueue(new Color(-0.1f, 0, 0));
        colorQ.Enqueue(new Color(0, 0, 0.1f));
        colorQ.Enqueue(new Color(0, -0.1f, 0));
        colorQ.Enqueue(new Color(0.1f, 0, 0));
        colorQ.Enqueue(new Color(0, 0, -0.1f));
        
        while (true)
        {
            for(int i = 0; i<10; i++){
                newBestScoreText.color+=colorQ.Peek();
                yield return wait;
            }
            colorQ.Enqueue(colorQ.Peek());
            colorQ.Dequeue();
        }
    }
}