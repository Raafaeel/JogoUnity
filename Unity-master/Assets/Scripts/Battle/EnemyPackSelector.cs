using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Battle{
public class EnemyPackLoader : MonoBehaviour
{
    [System.Serializable]
    public class SceneEnemyPackMapping
    {
        public string SceneName;
        public EnemyPack EnemyPack;
    }

    public List<SceneEnemyPackMapping> SceneMappings;

    public EnemyPack GetEnemyPackForCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        foreach (var mapping in SceneMappings)
        {
            if (mapping.SceneName == currentSceneName)
                return mapping.EnemyPack;
        }

        Debug.LogWarning($"Nenhuma EnemyPack foi encontrada para a cena: {currentSceneName}");
        return null;
    }
}
}