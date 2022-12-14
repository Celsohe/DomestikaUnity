using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    private Hp heroHp;
    //  private Rigidbody2D _rb;


    void Start()
    {
        heroHp.hp = 1;
    }


    void Update()
    {
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                heroHp.hp -= 1;
            }
        }
        

        if (heroHp.hp <= 0)
        {
            Destroy(this);
        }
    }
}

        



