using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioPlayer))]
public class AudioPlayerEditor : Editor
{
    private AudioPlayer audioPlayer;
    private int indexInput = 0;

    private void OnEnable()
    {
        audioPlayer = (AudioPlayer)target;
        indexInput = audioPlayer.musicIndex;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space(15);
        EditorGUILayout.LabelField("Controles de Música", EditorStyles.boldLabel);
        EditorGUILayout.Separator();

        // Campo para digitar o índice
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Índice da Música:", GUILayout.Width(120));
        indexInput = EditorGUILayout.IntField(indexInput, GUILayout.Width(60));
        
        if (GUILayout.Button("Tocar", GUILayout.Width(80)))
        {
            audioPlayer.PlayMusic(indexInput);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);

        // Botões de controle
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("▶ Play Atual", GUILayout.Height(35)))
        {
            audioPlayer.PlayMusic(audioPlayer.musicIndex);
        }

        if (GUILayout.Button("⏸ Pause", GUILayout.Height(35)))
        {
            audioPlayer.Pause();
        }

        if (GUILayout.Button("⏵ Resume", GUILayout.Height(35)))
        {
            audioPlayer.Resume();
        }

        if (GUILayout.Button("⏹ Stop", GUILayout.Height(35)))
        {
            audioPlayer.Stop();
        }

        EditorGUILayout.EndHorizontal();
    }
}



