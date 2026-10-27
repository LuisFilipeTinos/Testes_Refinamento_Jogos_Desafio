using UnityEngine;

public class Gol : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Bola bola = other.GetComponent<Bola>();
        if (bola != null)
        {
            Debug.Log("GOL!");
            GameManager.Instancia.AdicionarPonto();
            bola.gameObject.SetActive(false);
        }
    }
}
