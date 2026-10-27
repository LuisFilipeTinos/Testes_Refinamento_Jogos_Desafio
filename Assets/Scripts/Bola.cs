using UnityEngine;

public class Bola : MonoBehaviour
{
    private Vector3 posicaoInicial;

    void Awake()
    {
        posicaoInicial = transform.position;
    }

    public void Respawn()
    {
        transform.position = posicaoInicial;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = posicaoInicial;
            RigidbodyCompat.SetVelocity(rb, Vector3.zero);
        }
    }
}
