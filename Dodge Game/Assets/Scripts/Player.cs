using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private FlashMaterial flashMaterial;
    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 500.0f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flashMaterial = GetComponent<FlashMaterial>();
        
    }

    
    void Update()
    {
        Keyboard();
    }

    void FixedUpdate()
    {
        Move();
        Reverse();

    }
    void Move()
    {
        if(rigidbody2D.velocity == Vector2.zero)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }

        rigidbody2D.velocity = new Vector3(direction.x, direction.y, 0) * speed * Time.fixedDeltaTime;
    }

    void Keyboard()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void Reverse()
    {
        if (direction.x < 0)
        {
            
            spriteRenderer.flipX = false;
        }
        else if (direction.x > 0)
        {
           
            spriteRenderer.flipX = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid astroid = collision.GetComponent<Asteroid>();

        if(astroid != null)
        {
            StartCoroutine(flashMaterial.HitEffect(0.25f));
            
        }
    }

}
