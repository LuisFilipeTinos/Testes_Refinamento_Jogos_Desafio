using UnityEngine;

public class Moeda : MonoBehaviour
{
    public float velocidadeGiro = 90f;

    void Update()
    {
        transform.Rotate(0f, velocidadeGiro * Time.deltaTime, 0f, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instancia.AdicionarPonto();
            Destroy(gameObject);
        }
    }
}
