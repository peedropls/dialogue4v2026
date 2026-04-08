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
    // ── Singleton ──────────────────────────────────────────────────────────
    public static GameManager Instance { get; private set; }
 
    // ── Estado atual ───────────────────────────────────────────────────────
    public GameState CurrentState { get; private set; }
 
    // ── Nomes das cenas (edite se seus nomes forem diferentes) ─────────────
    [Header("Nomes das cenas")]
    [SerializeField] private string splashSceneName    = "Splash";
    [SerializeField] private string mainMenuSceneName  = "MenuPrincipal";
    [SerializeField] private string gameplaySceneName  = "SampleScene";
 
    // ──────────────────────────────────────────────────────────────────────
    private void Awake()
    {
        // Garante uma única instância e não destrói ao trocar de cena
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
 
        Instance = this;
        DontDestroyOnLoad(gameObject);
 
        // A cena _Boot é sempre a primeira → estado Iniciando
        ChangeState(GameState.Iniciando);
    }
 
    private void Start()
    {
        // Assim que a inicialização termina, vai para o Splash
        LoadScene(splashSceneName);
    }
 
    // ── Troca de estado ────────────────────────────────────────────────────
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"[GameManager] Estado alterado para: {newState}");
    }
 
    // ── Único ponto de carregamento de cenas no jogo ───────────────────────
    public void LoadScene(string sceneName)
    {
        // Defina o novo estado ANTES de carregar
        if (sceneName == splashSceneName)
            ChangeState(GameState.Splash);
        else if (sceneName == mainMenuSceneName)
            ChangeState(GameState.MenuPrincipal);
        else if (sceneName == gameplaySceneName)
            ChangeState(GameState.Gameplay);
 
        // Somente carrega se o estado atual permitir a transição
        if (IsTransitionAllowed(sceneName))
        {
            Debug.Log($"[GameManager] Carregando cena: {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"[GameManager] Transição para '{sceneName}' bloqueada no estado {CurrentState}.");
        }
    }
 
    // Regras simples de permissão de troca de cena
    private bool IsTransitionAllowed(string sceneName)
    {
        // No estado Gameplay, não permite voltar ao Splash
        if (CurrentState == GameState.Gameplay && sceneName == splashSceneName)
            return false;
 
        return true; // todas as outras transições são permitidas
    }
 
    // ── Alocação de Input (single player) ─────────────────────────────────
    // Chame este método passando o PlayerInput do jogador.
    // O GameManager alocará o primeiro dispositivo disponível.
    public void AllocateInputToPlayer(PlayerInput playerInput)
    {
        if (playerInput == null) return;
 
        // Pega o primeiro dispositivo conectado (teclado, gamepad, etc.)
        InputDevice[] devices = InputSystem.devices.ToArray();
        if (devices.Length > 0)
        {
            playerInput.SwitchCurrentControlScheme(devices[0]);
            Debug.Log($"[GameManager] Input '{devices[0].displayName}' alocado ao jogador.");
        }
        else
        {
            Debug.LogWarning("[GameManager] Nenhum dispositivo de input encontrado.");
        }
    }
 
    // ── Atalhos públicos para as cenas ─────────────────────────────────────
    public void GoToMainMenu()  => LoadScene(mainMenuSceneName);
    public void GoToGameplay()  => LoadScene(gameplaySceneName);
    public void GoToSplash()    => LoadScene(splashSceneName);
}
 