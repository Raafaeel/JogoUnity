/*using UnityEngine;
using Battle;
using Core;
using UnityEngine.SceneManagement;

namespace Battle {
public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    public Difficulty currentDifficulty = Difficulty.Medium;

    private void Awake()
    {
        // Garantir que apenas uma instância exista (Singleton)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;
        Debug.Log("Dificuldade configurada para: " + difficulty);

        SceneManager.LoadScene("LoadGame"); // Carrega a cena "LoadScene" que começa o jogo

    }

    public Difficulty GetDifficulty()
    {
        return currentDifficulty;
    }
}
}

*/

