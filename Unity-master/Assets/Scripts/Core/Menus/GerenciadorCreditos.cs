using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciadorcreditos : MonoBehaviour
{
    public void GoTocreditos()
    {
        SceneManager.LoadScene("creditos"); // Carrega a cena "créditos"
    }
}
