using UnityEngine;

public class AndroidToast : MonoBehaviour
{
    private AndroidJavaObject currentActivity;
    private AndroidJavaClass UnityPlayer;
    private AndroidJavaObject context;
    private AndroidJavaObject toast;

    void Awake()
    {
        UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
    }

    public void ShowToast(string message)
    {
        currentActivity.Call
        (
            "runOnUiThread",
            new AndroidJavaRunnable(() =>
            {
                AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
                AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", message);

                Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT")).Call("show");
            })
         );
    }

    public void CancelToast()
    {
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => toast?.Call("cancel")));
    }
}