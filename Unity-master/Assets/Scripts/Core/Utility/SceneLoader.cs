using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class SceneLoader
    {
        private static int battleSceneBuildIndex = 4; // Índice da cena de batalha
        private static Vector2 savedPlayerLocation;
        private static int savedPreviousSceneIndex; // Nova variável para armazenar a cena anterior

    public static void LoadBattleScene()
        {
        // Salva a cena atual como anterior
        savedPreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Obtém a cena de combate do mapa atual
        int battleSceneIndex = Game.World.Map.BattleSceneIndex;
        
        // Resto do código permanece igual...
        GameObject.DontDestroyOnLoad(Game.World.Map);
        Game.World.Map.gameObject.SetActive(false);
        savedPlayerLocation = Game.Player.CurrentCell.Center2D();
        
        SceneManager.LoadScene(battleSceneIndex); // Usa o índice do mapa
        SceneManager.sceneLoaded += DisablePlayerObject;
        }

        // Novo método para retornar à cena anterior
        public static void ReturnToPreviousScene()
        {
            SceneManager.sceneLoaded += RestorePlayerPosition;
            SceneManager.LoadScene(savedPreviousSceneIndex);
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