using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorComecar : MonoBehaviour
{
    public void GoTodificuldade()
    {
        SceneManager.LoadScene("dificuldade"); // Carrega a cena "dificuldade"
    }
}
