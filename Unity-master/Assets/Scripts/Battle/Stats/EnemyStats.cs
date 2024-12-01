using System;
using UnityEngine;

namespace Battle
{
    [Serializable]
    public class EnemyStats : BattleStats
    {
        [SerializeField] private int level;
        [SerializeField] private int baseHp;
        [SerializeField] private int baseMaxHp;
        [SerializeField] private int baseStr;
        [SerializeField] private int baseArm;
        [SerializeField] private int baseSpd;

        public override int Level => level;

        public override int HP => Mathf.Clamp(hp, 0, MaxHP);

        public override int MaxHP => Mathf.RoundToInt(baseMaxHp * DifficultyConfig.GetMultiplierHP());

        public override int STR => Mathf.RoundToInt(baseStr * DifficultyConfig.GetMultiplierSTR());

        public override int ARM => Mathf.RoundToInt(baseArm * DifficultyConfig.GetMultiplierARM());

        public override int SPD => baseSpd; // Velocidade pode não ser afetada pela dificuldade

        private int hp;

        private void Awake()
        {
            hp = MaxHP; // Inicializa HP com base na dificuldade
        }

        public override void ReduceHP(int amount)
        {
            if (amount <= 0)
                return;

            hp = Mathf.Clamp(hp - amount, 0, MaxHP);
        }
    }
}
