using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;

public class Paladin : Character
{
    public Weapon weapon;
    public Paladin(string name,Weapon weapon) : base()
    {
        this.weapon = weapon;
    }
}