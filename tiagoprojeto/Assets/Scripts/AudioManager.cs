using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource _systemSource;
    private List<AudioSource> _activeSources;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _systemSource = gameObject.GetComponent<AudioSource>();
            _activeSources = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Funções de gerenciamento de áudio
    public void PlaySound(AudioClip clip)
    {
        _systemSource.Stop();
        _systemSource.clip = clip;
        _systemSource.Play();
    }

    public void StopSound()
    {
        _systemSource.Stop();
    }
    
    public void PauseSound()
    {
        _systemSource.Pause();
    }
    
    public void ResumeSound()
    {
        _systemSource.UnPause();
    }
    
    public void PlayOneShot(AudioClip clip)
    {
        _systemSource.PlayOneShot(clip);
    }
    
    //Funções de gerenciamento do áudio 3d
    public void PlaySound(AudioClip clip, AudioSource source)
    {
        if(_activeSources.Contains(source)) _activeSources.Add(source);
        _activeSources.Add(source);
        source.Stop();
        source.clip = clip;
        source.Play();
    }
    
    public void StopSound(AudioSource source)
    {
        source.Stop();
        _activeSources.Remove(source);
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