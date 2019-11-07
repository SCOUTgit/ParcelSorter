using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    private void Start() => UpdateBestScore();

    public void UpdateBestScore()
    {
        gameObject.GetComponent<Text>().text = $"Best : {PlayerPrefs.GetInt("BestScore")}";
    }
}
