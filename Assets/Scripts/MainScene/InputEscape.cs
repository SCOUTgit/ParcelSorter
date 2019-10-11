using UnityEngine;
using UnityEngine.SceneManagement;

public class InputEscape : MonoBehaviour {
    private void Update() {
        if(Input.GetKey(KeyCode.Escape)){
                Application.Quit();
        }
    }
}