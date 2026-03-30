using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioPlayer))]
public class AudioPlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AudioPlayer audioPlayer = (AudioPlayer)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        // Dropdown para escolher a música
        if (audioPlayer.myAudioCollection != null && audioPlayer.myAudioCollection.AudioClipCollection.Count > 0)
        {
            string[] options = new string[audioPlayer.myAudioCollection.AudioClipCollection.Count];
            for (int i = 0; i < audioPlayer.myAudioCollection.AudioClipCollection.Count; i++)
            {
                options[i] = audioPlayer.myAudioCollection.AudioClipCollection[i] != null ? audioPlayer.myAudioCollection.AudioClipCollection[i].name : "Null";
            }

            int selectedIndex = EditorGUILayout.Popup("Select Music", audioPlayer.currentIndex, options);
            if (selectedIndex != audioPlayer.currentIndex)
            {
                audioPlayer.SetIndex(selectedIndex);
            }
        }

        // Campo para definir o índice
        int newIndex = EditorGUILayout.IntField("Music Index", audioPlayer.currentIndex);
        if (newIndex != audioPlayer.currentIndex)
        {
            audioPlayer.SetIndex(newIndex);
        }

        EditorGUILayout.Space();

        // Botões de controle
        if (GUILayout.Button("Play"))
        {
            audioPlayer.Play();
        }

        if (GUILayout.Button("Pause"))
        {
            audioPlayer.Pause();
        }

        if (GUILayout.Button("Resume"))
        {
            audioPlayer.Resume();
        }

        if (GUILayout.Button("Stop"))
        {
            audioPlayer.Stop();
        }
    }
}
