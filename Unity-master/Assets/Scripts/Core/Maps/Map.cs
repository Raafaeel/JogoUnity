using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private BattleRegion region;
        [SerializeField] private int battleSceneIndex = 4; // Novo campo para a cena de combate

        public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells { get; private set; }
        public Dictionary<Vector2Int, ITriggerTouch> TriggerCells { get; private set; }
        public Grid Grid { get; private set; }
        public BattleRegion Region => region;
        public int BattleSceneIndex => battleSceneIndex; // Nova propriedade de acesso

        private void Awake()
        {
            Grid = GetComponent<Grid>();
            OccupiedCells = new Dictionary<Vector2Int, MonoBehaviour>();
            TriggerCells = new Dictionary<Vector2Int, ITriggerTouch>();
            OccupiedCells.Clear();
        }
    }
}