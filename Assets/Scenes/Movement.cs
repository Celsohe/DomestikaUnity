using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float Intensity = 2f;
    public RaycastHit2D hit;
    private Animator anim;
    private float _lookingAt;
    private Collider2D _collider2D;
    private Rigidbody2D rb;
    private Vector3 direction;
    private SpriteRenderer _sr;
    private float _xAxis;
    private float jump;
    private bool _isGrounded;
    private Vector2 _ray;
    private Paladin hero = new Paladin("Craudio","trammboto");
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        hero.Name = "Tiberio";
        hero.weapon = 20000;
    }

    private void Update()
    {    
        _xAxis = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Vertical");
  
        if (_lookingAt < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        Debug.DrawRay(transform.position, Vector3.down * .125f, Color.red);
        checkcollision();
    }

    private void FixedUpdate()
    {

        direction = new Vector3(_xAxis, 0,0);
        if ( rb.velocity.magnitude < 2f && direction.magnitude != 0) 
        {
            rb.AddForce(direction*Time.fixedDeltaTime*10,ForceMode2D.Impulse);
            _lookingAt = _xAxis;
            anim.SetBool("isWalking",true);  
        }
        else
        {
            anim.SetBool("isWalking",false);  
        }
        
        if (jump>0 && _isGrounded)
        {
            rb.AddForce(new Vector2(0,50f)*Time.fixedDeltaTime,ForceMode2D.Impulse);
            Debug.Log("jumped");
            anim.SetBool("isJumping",true);
        }
        else
        {
            anim.SetBool("isJumping",false);
        }

    }

    public void checkcollision()
    {
        RaycastHit hot; 
        hit = Physics2D.Raycast(transform.position , Vector3.down, .125f,layerMask: 1);

        if (hit)
        {
            if (hit.rigidbody.transform.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
            
        }else _isGrounded = false;
    }   

    
    
    public void statusVEloTwo()
    {
       anim.SetInteger("static" , 2);
    }

    public void statusVEloThree()
    {
        anim.SetInteger("static" , 3);  
    }
    public void statusVEloOne()
    {
        anim.SetInteger("static" , 1);  
    }


    

}
