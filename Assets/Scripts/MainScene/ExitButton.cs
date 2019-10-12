using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => Exit());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
    
    private void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}