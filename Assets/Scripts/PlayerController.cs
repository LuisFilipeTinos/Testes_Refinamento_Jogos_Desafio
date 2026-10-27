using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float velocidade = 6f;
    public float forcaPulo = 8f;

    private Rigidbody rb;
    private PlayerControls playerControls;
    private Vector3 posicaoInicial;
    private Vector2 entrada;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        playerControls.Move.Move.Enable();
    }

    void OnDisable()
    {
        playerControls.Move.Move.Disable();
        playerControls.Move.Jump.Disable();
    }

    void Start()
    {
        gameManager.IniciarPartida();
    }

    void Update()
    {
        entrada = playerControls.Move.Move.ReadValue<Vector2>();

        if (playerControls.Move.Jump.WasPressedThisFrame() && EstaNoChao())
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 v = RigidbodyCompat.GetVelocity(rb);
        v.x = entrada.x * velocidade;
        v.z = entrada.y * velocidade;
        RigidbodyCompat.SetVelocity(rb, v);
    }

    bool EstaNoChao()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.GetComponent<Inimigo>() != null)
        {
            gameManager.PerderVida();
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = posicaoInicial;
        rb.position = posicaoInicial;
        RigidbodyCompat.SetVelocity(rb, Vector3.zero);
    }
}
