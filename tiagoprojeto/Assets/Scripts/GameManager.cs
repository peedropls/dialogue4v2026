using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum GameState
{
    Iniciando,
    Splash,
    MenuPrincipal,
    Gameplay
}

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    
    
    public GameState CurrentState { get; private set; }
    
    
    [Header("Nomes das cenas")]
    [SerializeField] private string splashSceneName = "Splash";
    [SerializeField] private string mainMenuSceneName = "MenuPrincipal";
    [SerializeField] private string gameplaySceneName = "SampleScene";
    [SerializeField] private string guiSceneName = "GUI";
    
    
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ChangeState(GameState.Iniciando);
    }

    private void Start()
    {
        
        LoadScene(splashSceneName);
        
    }

    
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"[GameManager] Estado alterado para: {newState}");
    }

    
    public void LoadScene(string sceneName)
    {
        
        if (sceneName == splashSceneName)
            ChangeState(GameState.Splash);
        else if (sceneName == mainMenuSceneName)
            ChangeState(GameState.MenuPrincipal);
        else if (sceneName == gameplaySceneName)
            ChangeState(GameState.Gameplay);

        
        if (IsTransitionAllowed(sceneName))
        {
            Debug.Log($"[GameManager] Carregando cena: {sceneName}");

            
            SceneManager.LoadScene(sceneName);

            
            if (sceneName == gameplaySceneName)
            {
                SceneManager.LoadScene(guiSceneName, LoadSceneMode.Additive);
            }
            
            else
            {
                
                Scene guiScene = SceneManager.GetSceneByName(guiSceneName);

                if (guiScene.isLoaded)
                {
                    SceneManager.UnloadSceneAsync(guiSceneName);
                }
            }
        }
        else
        {
            Debug.LogWarning($"[GameManager] Transição para '{sceneName}' bloqueada.");
        }
    }

    
    private bool IsTransitionAllowed(string sceneName)
    {
        
        if (CurrentState == GameState.Gameplay && sceneName == splashSceneName)
            return false;

        return true;
    }

    
    public void AllocateInputToPlayer(PlayerInput playerInput)
    {
        if (playerInput == null) return;
        
        
        InputDevice[] devices = InputSystem.devices.ToArray();

        if (devices.Length > 0)
        {
            playerInput.SwitchCurrentControlScheme(devices[0]);

            Debug.Log($"[GameManager] Input '{devices[0].displayName}' alocado.");
        }
        else
        {
            Debug.LogWarning("[GameManager] Nenhum dispositivo encontrado.");
        }
    }
    
    
    public void GoToMainMenu() => LoadScene(mainMenuSceneName);

    public void GoToGameplay() => LoadScene(gameplaySceneName);

    public void GoToSplash() => LoadScene(splashSceneName);
    
}
 