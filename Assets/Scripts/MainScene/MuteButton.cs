using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField]
    private Image muteImage;
    [SerializeField]
    private Image unmuteImage;

    private Image image;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Mute") == 1){
            image = muteImage;
            SoundManager.instance.Mute();
        }
        image = gameObject.GetComponent<Image>();
        gameObject.GetComponent<Button>().onClick.AddListener(() => Mute());
    }

    private void Mute()
    {
        if (SoundManager.instance.isMute)
        {
            image = unmuteImage;
            SoundManager.instance.Unmute();
        }
        else
        {
            image = muteImage;
            SoundManager.instance.Mute();
        }
        PlayerPrefs.SetInt("Mute", SoundManager.instance.isMute ? 1 : 0);
    }
}