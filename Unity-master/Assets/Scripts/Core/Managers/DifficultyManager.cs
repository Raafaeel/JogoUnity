using UnityEngine;
using System.Collections;
using Core;

public class DifficultyManager : MonoBehaviour
{
    // Singleton instance
    public static DifficultyManager Instance { get; private set; }
    
    private StateManager stateManager;
    
    // Current difficulty (default to Medium)
    public Battle.Difficulty currentDifficulty = Battle.Difficulty.Medium;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
    }

    public void Initialize(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }


    public void SetDifficultyAndLoad(Battle.Difficulty newDifficulty)
    {
        currentDifficulty = newDifficulty;
        Debug.Log($"Difficulty changed to: {newDifficulty}");
        ApplyDifficultySettings();
    }

    public void ApplyDifficultySettings()
    {
        switch (currentDifficulty)
        {
            case Battle.Difficulty.Easy:
                // Implement easy mode settings
                Debug.Log("Applying Easy difficulty settings");
                break;
            case Battle.Difficulty.Medium:
                // Implement medium mode settings
                Debug.Log("Applying Medium difficulty settings");
                break;
            case Battle.Difficulty.Hard:
                // Implement hard mode settings
                Debug.Log("Applying Hard difficulty settings");
                break;
        }
    }
}