using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scenes
{
    public class Character
    {
        public string Name;
        public int experience;

        public Character(string name, int experience)
        {
            this.Name = name;
            this.experience = 0;
        }
        
    }
    
    public struct Weapon
    {
        public string Name;
        public int Damage;
        
        public Weapon(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
        }
    }
    
}
