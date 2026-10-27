using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Vector3 pontoA;
    public Vector3 pontoB;
    public float velocidade = 4f;

    private Vector3 destino;

    void Start()
    {
        destino = pontoB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade);

        if (Vector3.Distance(transform.position, destino) < 0.05f)
        {
            destino = (destino == pontoA) ? pontoB : pontoA;
        }
    }
}
