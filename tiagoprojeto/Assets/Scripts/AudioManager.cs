using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource systemAudioSource;
    private List<AudioSource> activeSources;
    
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
    
    // Funções de gerenciamento de áudio
    public void PlaySound(AudioClip clip)
    {
        systemAudioSource.Stop();
        systemAudioSource.clip = clip;
        systemAudioSource.Play();
    }

    public void StopSound()
    {
        systemAudioSource.Stop();
    }
    
    public void PauseSound()
    {
        systemAudioSource.Pause();
    }
    
    public void ResumeSound()
    {
        systemAudioSource.UnPause();
    }
    
    public void PlayOneShot(AudioClip clip)
    {
        systemAudioSource.PlayOneShot(clip);
    }
    
    //Funções de gerenciamento do áudio 3d
    public void PlaySound(AudioClip clip, AudioSource source)
    {
        if(activeSources.Contains(source)) activeSources.Add(source);
        activeSources.Add(source);
        source.Stop();
        source.clip = clip;
        source.Play();
    }
    
    public void StopSound(AudioSource source)
    {
        source.Stop();
        activeSources.Remove(source);
    }
    
    public void PauseSound(AudioSource source)
    {
        source.Pause();
    }
    
    public void ResumeSound(AudioSource source)
    {
        source.UnPause();
    }
    
    public void PlayOneShot(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }
    
    
}