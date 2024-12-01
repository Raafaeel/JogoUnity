using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void GoToMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Troca para a cena "MenuPrincipal"
    }
}
