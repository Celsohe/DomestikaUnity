using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float Intensity = 2f;
    public RaycastHit2D hit;
    public GameObject menu;

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
    private bool _isMenu;
    private bool _isMenuActive;
    private bool _isPaused;
    private Transform activation;

    private void Awake()
    {
        Hp.hp = 2;
        Hp.instantHealth = 20;
        Hp.maxHealth = 10;
        Hp.obj = this.gameObject;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        //menu.SetActive(false);

    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Vertical");
        _isMenu = Input.GetKeyDown("space");

        if (_lookingAt < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Debug.DrawRay(transform.position, Vector3.down * .125f, Color.red);

        if (_isMenu)
        {
            PauseGame();
        }
    }

    private void FixedUpdate()
    {
        checkcollision();
       // MasBateu();

       direction = new Vector3(_xAxis, 0, 0);
        if (rb.velocity.magnitude < 2f && direction.magnitude != 0)
        {
            rb.AddForce(direction * Time.fixedDeltaTime * 10, ForceMode2D.Impulse);
            _lookingAt = _xAxis;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (jump > 0 && _isGrounded)
        {
            rb.AddForce(new Vector2(0, 90f) * Time.fixedDeltaTime, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    public void checkcollision()
    {
        RaycastHit hot;
        hit = Physics2D.Raycast(transform.position, Vector3.down, .125f, layerMask: 1);

        if (hit)
        {
            if (hit.rigidbody.transform.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
        else
            _isGrounded = false;
    }

    public void statusVEloTwo()
    {
        anim.SetInteger("static", 2);
    }

    public void statusVEloThree()
    {
        anim.SetInteger("static", 3);
    }

    public void statusVEloOne()
    {
        anim.SetInteger("static", 1);
    }

    public void PauseGame()
    {
        if (_isPaused == false)
        {
            Time.timeScale = 0;
            _isPaused = true;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            _isPaused = false;
            menu.SetActive(false);
        }
    }
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Villain"))
            {
               Hp.TookDamage(1); 

            }
        }
    
}