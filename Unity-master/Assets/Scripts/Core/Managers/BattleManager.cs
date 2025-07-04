using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;
using UnityEngine.SceneManagement;

namespace Core
{
    public class BattleManager
    {
        private StateManager stateManager;
        private GameObject battleTransition;

        public BattleManager(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.battleTransition = Resources.Load<GameObject>("Transitions/BattleTransition");
        }

        public void StartBattle(EnemyPack pack)
        {
            if (stateManager.TryState(GameState.Battle))
                Game.Player.StartCoroutine(Co_StartBattle(pack));
        }

        private IEnumerator Co_StartBattle(EnemyPack pack)
        {
            BattleControl.EnemyPack = pack;

            Animator animator = PlayTransition();
            while (animator.IsAnimating()) 
                yield return null;

            SceneLoader.LoadBattleScene();
        }

        public void EndBattle()
        {
            SceneManager.LoadScene("BattleVictory");
            stateManager.RestorePreviousState();
        }

        private Animator PlayTransition()
        {
            Vector3 position = Game.Player.transform.position;
            Animator animator = GameObject.Instantiate(battleTransition, position, Quaternion.identity).GetComponent<Animator>();
            return animator;
        }
    }
}
