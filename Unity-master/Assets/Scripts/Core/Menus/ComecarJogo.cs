using UnityEngine;
using UnityEngine.SceneManagement;

public class ComecarJogo : MonoBehaviour
{
    public void GoToLoadGame()
    {
        SceneManager.LoadScene("LoadGame"); // Carrega a cena "dificuldade"
    }
}
