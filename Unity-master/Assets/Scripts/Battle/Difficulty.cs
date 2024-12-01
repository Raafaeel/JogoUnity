using UnityEngine;
using Core;
using Battle;

namespace Battle
{
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
    }

    public Difficulty GetDifficulty()
    {
        return currentDifficulty;
    }
}
}
