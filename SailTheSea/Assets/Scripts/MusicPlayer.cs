using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip defaultSong;
    public AudioClip secretSong;
    private AudioSource audioSource;
    private string inputCode = string.Empty;
    private string secretCode = "mobbyn";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = defaultSong;
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    void Update()
    {
        if (Input.anyKeyDown && !PauseMenu.isPaused)
        {
            inputCode += Input.inputString;
            if (inputCode.Length > secretCode.Length)
            {
                inputCode = inputCode.Substring(1);
            }
            if (inputCode == secretCode)
            {
                audioSource.clip = secretSong;
                audioSource.Play();
                inputCode = string.Empty;
            }
        }
    }
}