using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiSi_PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;
    public Text announceText;

    //audio stuff
    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        announceText.text = "Catch As Many Tennis Balls As You Can!";
    }
    
    void Awake()
    {
    source = GetComponent<AudioSource>();
    }
   

    void Update()
    {
      

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        //Debug.Log(isOnGround);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
       
    }

   

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "KiSi_ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = Vector2.up * jumpforce;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpClip);
            }
       

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("KiSi_Ball"))
        {
            other.gameObject.SetActive(false);
        }
    }
   

}
