using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public System.Action GameOver;

    [SerializeField]
    private float startTime;
    [SerializeField]
    private float lastTime;
    [SerializeField]
    private float subTime;

    float time;
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine(MeasureTime());
    }

    public void SetTimer(int score)
    {
        time = startTime;
        if (startTime - subTime > lastTime)
            startTime -= subTime;
        image.color = new Color(1, (255 - score * 2)/255f, 0, 1);
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
        GameOver();
        yield break;
    }
}
