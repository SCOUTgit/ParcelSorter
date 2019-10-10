using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    private void Start() => gameObject.GetComponent<Text>().text = $"Best : {PlayerPrefs.GetInt("BestScore")}";
}
