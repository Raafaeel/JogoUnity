using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class GarouStats : PartyMemberStats
    {
        protected PartyMember member;
        protected int level;
        

        // PartyMemberStats
        public override int BaseMaxHP => level * 13;
        public override int BaseSTR => 8 + (level * 2);
        public override int BaseARM => 8 + (level * 2);
        public override int BaseSPD => level;

        // BattleStats
        public override int Level => level;
        public override int HP => hp;
        public override int MaxHP => BaseMaxHP;
        public override int STR => member.EquippedWeapon is null ? BaseSTR : BaseSTR + member.EquippedWeapon.StrBonus;
        public override int ARM => member.EquippedArmor is null ? BaseARM : BaseARM + member.EquippedArmor.ArmBonus;
        public override int SPD => BaseSPD;
        public int Rage { get; private set; }

        public GarouStats(PartyMember member, int level)
        {
            this.member = member;
            this.level = level;
            this.hp = BaseMaxHP;
            this.Rage = 0;
        }

        public void GainRage(int amount)
        {
            if (amount <= 0)
                return;

            Rage = Mathf.Min(Rage + amount, Level);
        }

        public void LoseRage(int amount)
        {
            if (amount <= 0)
                return;

            Rage = Mathf.Max(Rage - amount, 0);
        }
    }
}
