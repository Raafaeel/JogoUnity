using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void GoToMenuPrincipal()
    {
        SceneManager.LoadScene("1 (Tela Principal)"); // Troca para a cena "MenuPrincipal"
    }
}
