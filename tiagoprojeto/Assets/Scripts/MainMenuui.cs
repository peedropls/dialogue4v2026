using UnityEngine;
using UnityEngine.UI;
 
// Coloque este script num GameObject na cena MenuPrincipal.
// No Inspector, arraste os botões nos campos startButton e quitButton.
public class MainMenuUI : MonoBehaviour
{
    [Header("Botões do Menu")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
 
    private void Start()
    {
        // Registra os callbacks dos botões
        startButton.onClick.AddListener(OnStartClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }
 
    private void OnStartClicked()
    {
        Debug.Log("[MainMenuUI] Botão Iniciar pressionado.");
        GameManager.Instance.GoToGameplay();
    }
 
    private void OnQuitClicked()
    {
        Debug.Log("[MainMenuUI] Botão Sair pressionado.");
        Application.Quit();
 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
 
    private void OnDestroy()
    {
        // Boa prática: remover listeners ao destruir o objeto
        startButton.onClick.RemoveListener(OnStartClicked);
        quitButton.onClick.RemoveListener(OnQuitClicked);
    }
}