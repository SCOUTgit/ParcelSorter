using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseBoard : MonoBehaviour
{
    [SerializeField]
    private Button replayButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button goMainButton;

    public System.Action action;

    private void Start()
    {
        Time.timeScale = 0;
        replayButton.onClick.AddListener(() => Destroy(gameObject));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
        goMainButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        action();
    }
}