using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void Start() => gameObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
}