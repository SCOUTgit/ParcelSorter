using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float subTime;

    float time;
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine(MeasureTime());
    }

    public void SetTimer()
    {
        time = startTime;
        startTime -= subTime;
    }

    private IEnumerator MeasureTime()
    {
        time = startTime;
        WaitForSeconds seconds = new WaitForSeconds(0.02f);
        while (time > 0)
        {
            time -= 0.02f;
            image.fillAmount = time / startTime;
            yield return seconds;
        }
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
        yield break;
    }
}
