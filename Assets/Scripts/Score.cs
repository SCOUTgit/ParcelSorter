using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score { get; private set; } = 0;

    private Text scoreText;

    private void Start() => scoreText = gameObject.GetComponent<Text>();

    public void SetText()
    {
        score++;
        scoreText.text = $"Score : {score}";
    }
}