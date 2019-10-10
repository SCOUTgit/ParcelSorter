using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField]
    private Sprite muteSprite;
    [SerializeField]
    private Sprite unmuteSprite;
    [SerializeField]
    private Image image;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Mute") == 1){
            image.sprite = muteSprite;
            SoundManager.instance.Mute();
        }
        gameObject.GetComponent<Button>().onClick.AddListener(() => Mute());
    }

    private void Mute()
    {
        if (SoundManager.instance.isMute)
        {
            image.sprite = unmuteSprite;
            SoundManager.instance.Unmute();
        }
        else
        {
            image.sprite = muteSprite;
            SoundManager.instance.Mute();
        }
        PlayerPrefs.SetInt("Mute", SoundManager.instance.isMute ? 1 : 0);
    }
}