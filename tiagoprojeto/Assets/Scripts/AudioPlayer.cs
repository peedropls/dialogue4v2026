using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioCollection myAudioCollection;
    public int currentIndex;

    void Start()
    {
        if (myAudioCollection != null && myAudioCollection.audioClipCollection.Count > 0 && currentIndex >= 0 && currentIndex < myAudioCollection.audioClipCollection.Count)
        {
            AudioManager.Instance.PlaySound(myAudioCollection.audioClipCollection[currentIndex]);
        }
    }

    public void Play()
    {
        if (myAudioCollection != null && myAudioCollection.audioClipCollection.Count > 0 && currentIndex >= 0 && currentIndex < myAudioCollection.audioClipCollection.Count)
        {
            AudioManager.Instance.PlaySound(myAudioCollection.audioClipCollection[currentIndex]);
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
        currentIndex = Mathf.Clamp(index, 0, myAudioCollection.audioClipCollection.Count - 1);
    }

    public void PlayNext()
    {
        currentIndex = (currentIndex + 1) % myAudioCollection.audioClipCollection.Count;
        Play();
    }

    public void PlayPrevious()
    {
        currentIndex = (currentIndex - 1 + myAudioCollection.audioClipCollection.Count) % myAudioCollection.audioClipCollection.Count;
        Play();
    }
}