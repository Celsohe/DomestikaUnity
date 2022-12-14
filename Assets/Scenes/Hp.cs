using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class Hp
{
    public static int hp = 10;
    public static int maxHealth;
    public static GameObject obj;
    

    public static int instantHealth
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp >= maxHealth)
            {
                hp = maxHealth;
            }
        }
    }

    public static void TookDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            obj.IsDestroyed();
        }
    }

    public static void GotHealth(int cure)
    {
        hp = hp + cure;
        if (hp >= maxHealth)
        {
            hp = maxHealth;
        }
    }
    
}
