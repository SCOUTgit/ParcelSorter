using UnityEngine;

public class CameraResoultion : MonoBehaviour
{
    [SerializeField]
    private int targetWidthAspect;
    [SerializeField]
    private int targetHeightAspect;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        var camera = gameObject.GetComponent<Camera>();

        float widthRatio = (float)Screen.width / targetWidthAspect;
        float heightRatio = (float)Screen.height / targetHeightAspect;

        float widthAdd = 0;
        float heightAdd = 0;

        if (widthRatio > heightRatio)
            widthAdd = 1 - heightRatio / widthRatio;
        else
            heightAdd = 1 - widthRatio / heightRatio;

        camera.rect = new Rect(widthAdd / 2, heightAdd / 2, camera.rect.width - widthAdd, camera.rect.height - heightAdd);

        var backgroundCamera = new GameObject("BackgroundCam", typeof(Camera)).GetComponent<Camera>();
        backgroundCamera.depth = int.MinValue;
        backgroundCamera.clearFlags = CameraClearFlags.SolidColor;
        backgroundCamera.backgroundColor = Color.black;
        backgroundCamera.cullingMask = 0;
    }
}