// This script handles the SFX management.
// Made by Vonce Chew

using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource musicSource; // Music Source

    public AudioSource sfxSource; // SFX Source

    public AudioClip popAudio; // Click Sound Audio

    

    public AudioClip BackgroundMusic; // Lobby Background Music

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Plays pop audio when function is called
    /// </summary>
    public void PlayPopAudio()
    {
        if (popAudio != null)
        {
            sfxSource.PlayOneShot(popAudio); // Plays click audio once
        }
        
        else
        {
            Debug.Log("No pop audio assigned");
            return;
        }
    }
}