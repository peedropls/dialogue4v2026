using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioCollection myAudioCollection;
    public int currentIndex = 0;

    void Start()
    {
        if (myAudioCollection != null && myAudioCollection.AudioClipCollection.Count > 0 && currentIndex >= 0 && currentIndex < myAudioCollection.AudioClipCollection.Count)
        {
            AudioManager.Instance.PlaySound(myAudioCollection.AudioClipCollection[currentIndex]);
        }
    }

    public void Play()
    {
        if (myAudioCollection != null && myAudioCollection.AudioClipCollection.Count > 0 && currentIndex >= 0 && currentIndex < myAudioCollection.AudioClipCollection.Count)
        {
            AudioManager.Instance.PlaySound(myAudioCollection.AudioClipCollection[currentIndex]);
        }
    }

    public void Pause()
    {
        AudioManager.Instance.PauseSound();
    }

    public void Resume()
    {
        AudioManager.Instance.ResumeSound();
    }

    public void Stop()
    {
        AudioManager.Instance.StopSound();
    }

    public void SetIndex(int index)
    {
        currentIndex = Mathf.Clamp(index, 0, myAudioCollection.AudioClipCollection.Count - 1);
    }

    public void PlayNext()
    {
        currentIndex = (currentIndex + 1) % myAudioCollection.AudioClipCollection.Count;
        Play();
    }

    public void PlayPrevious()
    {
        currentIndex = (currentIndex - 1 + myAudioCollection.AudioClipCollection.Count) % myAudioCollection.AudioClipCollection.Count;
        Play();
    }
}