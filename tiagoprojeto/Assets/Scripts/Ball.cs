using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controlador de jogador para um jogo do tipo Roll a Ball.
/// Gerencia o movimento da bola através de entrada de teclado (WASD) ou gamepad.
/// </summary>
public class PlayerBallController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField]
    [Tooltip("Força aplicada à bola quando o jogador se move")]
    private float movementForce = 15f;

    [SerializeField]
    [Tooltip("Velocidade máxima que a bola pode atingir")]
    private float maxSpeed = 15f;

    [SerializeField]
    [Tooltip("Amortecimento aplicado ao movimento (drag do Rigidbody)")]
    private float dragForce = 0.95f;

    [Header("Referências")]
    [SerializeField]
    [Tooltip("Componente Rigidbody da bola. Se vazio, tentará obter automaticamente")]
    private Rigidbody ballRigidbody;

    private Vector2 moveInput;

    private void Start()
    {
        // Se não tiver Rigidbody atribuído, tenta obter do GameObject
        if (ballRigidbody == null)
        {
            ballRigidbody = GetComponent<Rigidbody>();
        }

        // Validação
        if (ballRigidbody == null)
        {
            Debug.LogError("PlayerBallController: Nenhum Rigidbody encontrado! Adicione um Rigidbody ao GameObject.");
        }
    }

    private void Update()
    {
        // Captura input do teclado (WASD)
        moveInput = GetKeyboardInput();

        // Se não houver input de teclado, tenta capturar do gamepad
        if (moveInput == Vector2.zero)
        {
            moveInput = GetGamepadInput();
        }
    }

    private void FixedUpdate()
    {
        if (ballRigidbody == null) return;

        // Aplica força de movimento baseada no input
        ApplyMovement(moveInput);

        // Limita a velocidade máxima
        LimitSpeed();
    }

    /// <summary>
    /// Captura entrada de teclado (WASD ou setas)
    /// </summary>
    private Vector2 GetKeyboardInput()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current != null)
        {
            // WASD
            if (Keyboard.current.wKey.isPressed)
                vertical += 1f;
            if (Keyboard.current.sKey.isPressed)
                vertical -= 1f;
            if (Keyboard.current.aKey.isPressed)
                horizontal -= 1f;
            if (Keyboard.current.dKey.isPressed)
                horizontal += 1f;

            // Setas também funcionam
            if (Keyboard.current.upArrowKey.isPressed)
                vertical += 1f;
            if (Keyboard.current.downArrowKey.isPressed)
                vertical -= 1f;
            if (Keyboard.current.leftArrowKey.isPressed)
                horizontal -= 1f;
            if (Keyboard.current.rightArrowKey.isPressed)
                horizontal += 1f;
        }

        return new Vector2(horizontal, vertical).normalized;
    }

    /// <summary>
    /// Captura entrada de gamepad (analógico esquerdo)
    /// </summary>
    private Vector2 GetGamepadInput()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return Vector2.zero;

        return gamepad.leftStick.ReadValue();
    }

    /// <summary>
    /// Aplica força de movimento à bola
    /// </summary>
    private void ApplyMovement(Vector2 input)
    {
        if (input.magnitude < 0.01f) return;

        // Converte input 2D em força 3D (X e Z do espaço de jogo)
        Vector3 force = new Vector3(input.x, 0f, input.y) * movementForce;

        ballRigidbody.AddForce(force, ForceMode.Acceleration);
    }

    /// <summary>
    /// Limita a velocidade da bola para evitar aceleração infinita
    /// </summary>
    private void LimitSpeed()
    {
        if (ballRigidbody.linearVelocity.magnitude > maxSpeed)
        {
            // Reduz a velocidade mantendo a direção
            ballRigidbody.linearVelocity = ballRigidbody.linearVelocity.normalized * maxSpeed;
        }

        // Aplica amortecimento manual (decay)
        ballRigidbody.linearVelocity *= dragForce;
    }

    /// <summary>
    /// Reseta a posição e velocidade da bola (útil para restart do jogo)
    /// </summary>
    public void ResetBall(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        ballRigidbody.linearVelocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }
}