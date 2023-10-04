﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class NPC : Entity
    {
        public bool IsFriendly { get; set; }

        

        public NPC(string name, string description, int health, bool isFriendly, int dmg)
        {
            Name = name;
            Description = description;
            Health = health;
            IsFriendly = isFriendly;
            Dmg = dmg;

        }

        public int AttackPlayer()
        {
            return Dmg;
        }

        public int HealPlayer()
        {
            return 10;
        }

        public void TakeDamage(Player player)
        {
            Health -= player.Dmg;
        }

        public void GiveItem(Item item, Player player)
        {
            player.Inventory.Add(item);
        }

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nIs friendle: {IsFriendly}\nDamage: {Dmg}\nHealth: {Health}\n";
        }

    }
}
