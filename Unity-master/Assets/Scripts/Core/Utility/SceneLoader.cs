using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class SceneLoader
    {
        private static int battleSceneBuildIndex = 2; // Índice da cena de batalha
        private static Vector2 savedPlayerLocation;

        public static void LoadBattleScene()
        {
            // Salva o estado atual do jogo antes de carregar a cena de batalha
            GameObject.DontDestroyOnLoad(Game.World.Map);
            Game.World.Map.gameObject.SetActive(false);
            savedPlayerLocation = Game.Player.CurrentCell.Center2D();
            SceneManager.LoadScene(battleSceneBuildIndex);
            SceneManager.sceneLoaded += DisablePlayerObject;
        }

        public static void LoadNextSceneAfterBattle()
        {
            // Calcula o próximo índice da cena
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // Verifica se o próximo índice está dentro da lista de cenas no Build Settings
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning("Nenhuma próxima cena disponível no Build Settings!");
                return; // Não faz nada se não houver próxima cena
            }

            // Carrega a próxima cena
            SceneManager.sceneLoaded += RestorePlayerPosition;
            SceneManager.LoadScene(nextSceneIndex);
        }

        private static void RestorePlayerPosition(Scene scene, LoadSceneMode mode)
        {
            // Restaura o jogador após a troca de cena
            Game.Player.transform.position = savedPlayerLocation;
            Game.Player.gameObject.SetActive(true);
            SceneManager.sceneLoaded -= RestorePlayerPosition;
        }

        private static void DisablePlayerObject(Scene scene, LoadSceneMode mode)
        {
            // Desativa o jogador na cena de batalha
            Game.Player.gameObject.SetActive(false);
            SceneManager.sceneLoaded -= DisablePlayerObject;
        }
    }
}
