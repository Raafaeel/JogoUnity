using UnityEngine;
using UnityEngine.SceneManagement; // Adicione esta linha
using Battle;
using Core;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }
    public Battle.Difficulty currentDifficulty = Battle.Difficulty.Medium;

    private StateManager stateManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetStateManager(StateManager manager)
    {
        stateManager = manager;
    }

    public void SetDifficultyAndLoad(Battle.Difficulty newDifficulty)
    {
        currentDifficulty = newDifficulty;
        Debug.Log($"Difficulty changed to: {newDifficulty}");
        ApplyDifficultySettings();
        
        SceneManager.LoadScene("LoadGame"); // Agora funcionará
    }

    private void ApplyDifficultySettings()
    {
        switch (currentDifficulty)
        {
            case Battle.Difficulty.Easy:
                Debug.Log("Applying Easy difficulty settings");
                break;
            case Battle.Difficulty.Medium:
                Debug.Log("Applying Medium difficulty settings");
                break;
            case Battle.Difficulty.Hard:
                Debug.Log("Applying Hard difficulty settings");
                break;
        }
    }
}