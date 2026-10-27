using UnityEngine;

public class ZonaVitoria : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.Instancia.Vencer();
        }
    }
}
