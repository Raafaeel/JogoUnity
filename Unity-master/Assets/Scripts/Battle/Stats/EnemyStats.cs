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

        public override int HP => baseHp; // Retorna o HP atual diretamente

        public override int MaxHP => Mathf.RoundToInt(baseMaxHp * DifficultyConfig.GetMultiplierHP());

        public override int STR => Mathf.RoundToInt(baseStr * DifficultyConfig.GetMultiplierSTR());

        public override int ARM => Mathf.RoundToInt(baseArm * DifficultyConfig.GetMultiplierARM());

        public override int SPD => baseSpd; // Velocidade pode não ser afetada pela dificuldade

        private void Awake()
        {
            // Inicializa o HP atual com o valor máximo
            baseHp = MaxHP;

            Debug.Log($"Inimigo criado com HP inicial: {baseHp}/{MaxHP}");
        }

        public override void ReduceHP(int amount)
        {
            if (amount <= 0)
                return;

            baseHp = Mathf.Clamp(baseHp - amount, 0, MaxHP); // Garante que o HP não seja menor que 0
            Debug.Log($"Inimigo sofreu dano de {amount}. HP atual: {baseHp}/{MaxHP}");
        }
    }
}
