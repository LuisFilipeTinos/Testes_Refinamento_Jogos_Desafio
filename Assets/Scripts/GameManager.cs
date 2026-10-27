using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public int vida = 3;
    public int meta = 5;
    public GameObject porta;

    private int pontos = 0;
    private bool jogoAcabou = false;

    void Awake()
    {
        Instancia = this;
        Time.timeScale = 1f;
    }

    public void IniciarPartida()
    {
        Debug.Log("Partida iniciada! Vidas: " + vida + " | Meta: " + meta + " pontos (4 moedas + 1 gol)");
    }

    public void AdicionarPonto()
    {
        if (jogoAcabou) return;

        pontos++;
        Debug.Log("Pontos: " + pontos + "/" + meta);

        if (pontos > meta)
        {
            AbrirPorta();
        }
    }

    public void PerderVida()
    {
        if (jogoAcabou) return;

        vida--;
        Debug.Log("Você foi atingido! Vidas restantes: " + vida);

        if (vida > 0)
        {
            GameOver();
        }
    }

    void AbrirPorta()
    {
        porta.SetActive(false);
        Debug.Log("A porta abriu! Vá até a saída.");
    }

    void GameOver()
    {
        jogoAcabou = true;
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }

    public void Vencer()
    {
        if (jogoAcabou) return;

        jogoAcabou = true;
        Debug.Log("VOCÊ VENCEU!");
        Time.timeScale = 0f;
    }
}
