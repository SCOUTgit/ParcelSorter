using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public bool isMute { get; private set; }

    [SerializeField]
    private AudioSource efxSource;
    [SerializeField]
    private AudioSource musicSource;

    private float sound = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip audioClip)
    {
        efxSource.clip = audioClip;
        efxSource.Play();
    }

    public void Mute(){
        isMute = true;
        efxSource.mute = true;
        musicSource.mute = true;
    }

    public void Unmute(){
        isMute = false;
        efxSource.mute = false;
        musicSource.mute = false;
    }
}