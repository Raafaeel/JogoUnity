using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class SceneLoader
    {
        private static int battleSceneBuildIndex = 5;
        private static int savedSceneBuildIndex;
        private static Vector2 savedPlayerLocation;
        private static Map preservedMap;

        public static void LoadBattleScene()
        {
            // 1. SALVAR A REFERÊNCIA DO MAPA ATUAL
            preservedMap = Game.World.Map;

            // 2. Impede que o mapa seja destruído ao carregar outra cena
            Object.DontDestroyOnLoad(preservedMap.gameObject);

            // 3. Desativa o mapa para não interferir na cena de batalha
            preservedMap.gameObject.SetActive(false);

            // 4. Salva dados relevantes
            savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            savedPlayerLocation = Game.Player.CurrentCell.Center2D();

            Debug.Log($"[SceneLoader] SALVANDO MAPA: {preservedMap.name} | " +
                      $"Cena: {SceneManager.GetActiveScene().name} " +
                      $"(Build Index: {savedSceneBuildIndex}) | " +
                      $"Posição: {savedPlayerLocation}");

            // 5. Carrega a cena de batalha
            SceneManager.LoadScene(battleSceneBuildIndex);
            SceneManager.sceneLoaded += DisablePlayerObject;
        }

        public static void ReloadSavedSceneAfterBattle()
        {
            Debug.Log($"[SceneLoader] RECARREGANDO CENA: " +
                      $"Build Index {savedSceneBuildIndex} | " +
                      $"MAP PRESERVED: {(preservedMap != null ? preservedMap.name : "NULL")}");

            SceneManager.sceneLoaded += RestoreMapAndPlayer;
            SceneManager.LoadScene(savedSceneBuildIndex);
        }

        public static void RestoreMapAndPlayer(Scene scene, LoadSceneMode mode)
        {
            if (preservedMap == null)
            {
                Debug.LogWarning("[SceneLoader] Mapa preservado não encontrado (foi destruído?). Abortando restauração.");
                SceneManager.sceneLoaded -= RestoreMapAndPlayer;
                return;
            }

            Debug.Log($"[SceneLoader] RESTAURANDO MAPA: {preservedMap.name} na cena: {scene.name}");

            // Reativa o mapa
            preservedMap.gameObject.SetActive(true);

            // Atualiza referência no MapManager
            Game.World.UpdateMap(preservedMap);
            Debug.Log($"[SceneLoader] MAPA ATUALIZADO NO MapManager: {Game.World.Map.name}");

            // Reposiciona o jogador
            Game.Player.transform.position = savedPlayerLocation;
            Game.Player.gameObject.SetActive(true);

            // Atualiza os sistemas do mapa
            RefreshMapSystems();

            SceneManager.sceneLoaded -= RestoreMapAndPlayer;
        }

        private static void RefreshMapSystems()
        {
            if (preservedMap == null)
            {
                Debug.LogWarning("[SceneLoader] Tentando atualizar sistemas, mas mapa está nulo.");
                return;
            }

            Debug.Log($"[SceneLoader] Atualizando sistemas do mapa: {preservedMap.name}");

            // Limpa células ocupadas
            preservedMap.OccupiedCells.Clear();

            // Atualiza personagens na nova cena
            foreach (Character character in GameObject.FindObjectsOfType<Character>(true))
            {
                Debug.Log($"[SceneLoader] Personagem atualizado: {character.name}");
                // Aqui pode adicionar lógica de re-registro se necessário
            }
        }

        private static void DisablePlayerObject(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == battleSceneBuildIndex)
            {
                Game.Player.gameObject.SetActive(false);
                Debug.Log("[SceneLoader] Jogador desativado na cena de batalha");
            }
            SceneManager.sceneLoaded -= DisablePlayerObject;
        }

        /// <summary>
        /// Remove o mapa preservado da memória, se necessário.
        /// Chame isso se for recarregar completamente o jogo ou uma nova fase.
        /// </summary>
        public static void ClearPreservedMap()
        {
            if (preservedMap != null)
            {
                Object.Destroy(preservedMap.gameObject);
                preservedMap = null;
                Debug.Log("[SceneLoader] Mapa preservado destruído manualmente.");
            }
        }
    }
}
