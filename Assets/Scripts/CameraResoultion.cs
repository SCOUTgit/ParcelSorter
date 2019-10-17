using UnityEngine;

public class CameraResoultion : MonoBehaviour
{
    [SerializeField]
    private int targetWidthAspect;
    [SerializeField]
    private int targetHeightAspect;

    private void Awake()
    {
        Screen.SetResolution(720, 1280, false);

        var camera = gameObject.GetComponent<Camera>();
        camera.aspect = (float)targetWidthAspect / targetHeightAspect;

        float widthRatio = (float)Screen.width / targetWidthAspect;
        float heightRatio = (float)Screen.height / targetHeightAspect;

        float widthAdd = 0;
        float heightAdd = 0;

        if (widthRatio > heightRatio)
            widthAdd = (heightRatio / widthRatio - 1) / 2;
        else
            heightAdd = (widthRatio / heightRatio - 1) / 2;

        camera.rect = new Rect(camera.rect.x + Mathf.Abs(widthAdd), camera.rect.y + Mathf.Abs(heightAdd), camera.rect.width + (widthAdd * 2), camera.rect.height + (heightAdd * 2));
    }
}