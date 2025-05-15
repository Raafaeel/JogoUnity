using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle {
    public class DifficultyManager : MonoBehaviour {
        public static DifficultyManager Instance;
        public Difficulty currentDifficulty = Difficulty.Medium;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("DifficultyManager inicializado.");
            } else {
                Destroy(gameObject);
            }
        }

        public void SetDifficulty(Difficulty difficulty) {
            currentDifficulty = difficulty;
            Debug.Log("Dificuldade: " + difficulty);

            // Verifica se a cena existe antes de carregar
            if (Application.CanStreamedLevelBeLoaded("LoadGame")) {
                SceneManager.LoadScene("LoadGame");
            } else {
                Debug.LogError("Cena 'LoadGame' não encontrada no Build Settings!");
                ListAllScenes(); // Mostra todas as cenas disponíveis
            }
        }

        private void ListAllScenes() {
            Debug.Log("### CENAS DISPONÍVEIS ###");
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                Debug.Log($"Índice {i}: {sceneName}");
            }
        }
    }
}