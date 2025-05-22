using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Battle;  // Namespace onde está o enum Difficulty
using System.Linq;

namespace Core
{
    public class Game : MonoBehaviour
    {
        private static StateManager stateManager;

        public static DialogueManager Dialogue { get; private set; }
        public static MenuManager Menu { get; private set; }
        public static BattleManager Battle { get; private set; }
        public static CutsceneManager Cutscenes { get; private set; }
        public static MapManager World { get; private set; }
        public static Player Player { get; private set; }
        public static GameState State => stateManager.State;

        [SerializeField] private Map startingMap;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Vector2Int startingCell;

        private void Awake()
        {
            CreateManagers();
            SpawnPlayer();

            DontDestroyOnLoad(Player);
            DontDestroyOnLoad(this);
        }

        private void CreateManagers()
        {
            stateManager = new StateManager();
            Dialogue = new DialogueManager(stateManager);
            Menu = new MenuManager(stateManager);
            Battle = new BattleManager(stateManager);
            Cutscenes = new CutsceneManager(stateManager);
            World = new MapManager(stateManager, startingMap);
        }

        private void SpawnPlayer()
        {
            Player = Instantiate(playerPrefab).GetComponent<Player>();
            Player.transform.position = startingCell.Center2D();
        }

        private void StartDifficulty()
        {
            // Acesso ao enum Difficulty através do namespace Battle
            Difficulty difficulty = DifficultyManager.Instance.currentDifficulty;

            switch (difficulty)
            {
                case Difficulty.Easy:
                    Debug.Log("Dificuldade: Fácil");
                    // Configurações para fácil
                    break;
                case Difficulty.Medium:
                    Debug.Log("Dificuldade: Médio");
                    // Configurações para médio
                    break;
                case Difficulty.Hard:
                    Debug.Log("Dificuldade: Difícil");
                    // Configurações para difícil
                    break;
            }
        }
    }
}