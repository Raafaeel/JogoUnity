// Assets/Scripts/Battle/DifficultyManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle
{
    public class DifficultyManager : MonoBehaviour
    {
        public static DifficultyManager Instance;
        public Difficulty CurrentDifficulty { get; private set; } = Difficulty.Medium;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("DifficultyManager initialized");
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetDifficultyAndLoad(Difficulty difficulty)
        {
            CurrentDifficulty = difficulty;
            Debug.Log($"Difficulty set to: {CurrentDifficulty}");
            
            if (Application.CanStreamedLevelBeLoaded("LoadGame"))
            {
                SceneManager.LoadScene("LoadGame");
                Debug.Log("Loading LoadGame scene");
            }
            else
            {
                Debug.LogError("LoadGame scene not found in Build Settings!");
            }
        }
    }
}