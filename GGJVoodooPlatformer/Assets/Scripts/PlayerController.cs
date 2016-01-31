using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.
    public bool doubleJump = true;
    public GameObject shotSpawn;
    public GameObject shotObject;
    public float shotSpeed = 10f;
    public float moveSpeed = 10f;


    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public float jumpForce = 1000f;         // Amount of force added when the player jumps.
    public Animator anim;                  // Reference to the player's animator component.
    public Transform groundCheck;          // A position marking where to check if the player is grounded.
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float fireRate;
    public AudioSource fireClip;
    GameController _controller;


    public bool grounded = false;          // Whether or not the player is grounded.

    float nextFire;
    bool _touched = false;


    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
//        _controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _controller.killPlayer();
        }
    }


    public void touched()
    {
        _touched = true;
        anim.SetBool("catch", true);
    }

    void Update()
    {
        if(!_touched)
        {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));
            //transform.position = m + (move * moveSpeed);

            var val = move * moveSpeed * Time.deltaTime;

            transform.position = new Vector2(transform.position.x + val, transform.position.y);
            // If the jump button is pressed and the player is grounded then the player should jump.
            if (Input.GetButtonDown("Jump") && (grounded || doubleJump))
            {
                //anim.SetBool("Grounded", false);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                if (!grounded)
                    doubleJump = false;
            }

            if (Input.GetButton("Fire1"))
            {
                //anim.SetBool("Shooting", true);
            }
            else
            {
                //anim.SetBool("Shooting", false);
            }
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded)
            doubleJump = true;

        if(!_touched)
        {
            float move = Input.GetAxis("Horizontal");

            //GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (facingRight && move < 0)
                Flip();
            else if (!facingRight && move > 0)
                Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
