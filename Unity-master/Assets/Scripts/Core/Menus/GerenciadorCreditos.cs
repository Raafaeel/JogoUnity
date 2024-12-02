using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciadorcreditos : MonoBehaviour
{
    public void GoTocreditos()
    {
        SceneManager.LoadScene("3 (creditos)"); // Carrega a cena "créditos"
    }
}
