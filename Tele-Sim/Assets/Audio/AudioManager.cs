using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip gameMusic;
    public AudioClip smallAlertSound;
    public AudioClip bigAlertSound;
    public AudioClip emailAlertSound;
    public AudioClip clickSound;
    public AudioClip gameEndSound;

    private AudioSource musicSource;
    private AudioSource soundSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //audiosourcet
        musicSource = gameObject.AddComponent<AudioSource>();
        soundSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.playOnAwake = false;
        soundSource.playOnAwake = false;
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (gameMusic != null)
        {
            musicSource.clip = gameMusic;
            musicSource.Play();
        }
    }

    public void PlaySmallAlertSound()
    {
        if (smallAlertSound != null)
        {
            soundSource.PlayOneShot(smallAlertSound);
        }
    }

    public void PlayBigAlertSound()
    {
        if (bigAlertSound != null)
        {
            soundSource.PlayOneShot(bigAlertSound);
        }
    }
    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            soundSource.PlayOneShot(clickSound);
        }
    }
    public void PlayEmailAlertSound()
    {
        if (emailAlertSound != null)
        {
            soundSource.PlayOneShot(emailAlertSound);
        }
    }

    public void PlayGameEndSound()
    {
        if (gameEndSound != null)
        {
            musicSource.Stop();
            soundSource.PlayOneShot(gameEndSound);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}