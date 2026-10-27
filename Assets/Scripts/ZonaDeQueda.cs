using UnityEngine;

public class ZonaDeQueda : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("O jogador caiu! Voltando ao início.");
            player.Respawn();
            return;
        }

        Bola bola = other.GetComponent<Bola>();
        if (bola != null)
        {
            bola.Respawn();
        }
    }
}
