using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Battle
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public class DifficultyManager : MonoBehaviour
    {
        public static DifficultyManager Instance;
        public Difficulty currentDifficulty = Difficulty.Medium;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            currentDifficulty = difficulty;
            StartCoroutine(LoadGameScene());
        }

        private IEnumerator LoadGameScene()
        {
            const string sceneName = "LoadGame";
            
            if (!SceneExists(sceneName))
            {
                Debug.LogError("Cena não encontrada: " + sceneName);
                yield break;
            }

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }

        private bool SceneExists(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                if (System.IO.Path.GetFileNameWithoutExtension(scenePath) == sceneName)
                    return true;
            }
            return false;
        }
    }
}