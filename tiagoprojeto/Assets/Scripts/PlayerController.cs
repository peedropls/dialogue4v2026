using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float moveForce = 500f;
    [SerializeField] private float maxSpeed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        
        _rb.AddForce(movement * moveForce);

        // Limitar velocidade
        if (_rb.linearVelocity.magnitude > maxSpeed)
        {
            _rb.linearVelocity = Vector3.ClampMagnitude(_rb.linearVelocity, maxSpeed);
        }
    }
}