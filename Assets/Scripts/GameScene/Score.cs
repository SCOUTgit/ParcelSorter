using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score { get; private set; }

    private Text scoreText;

    private void Start()
    {
        score = 0;
        scoreText = gameObject.GetComponent<Text>();
    }

    public void SetText()
    {
        score++;
        scoreText.text = $"Score : {score}";
    }

    public void SaveScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore < score)
            PlayerPrefs.SetInt("BestScore", score);
    }
}