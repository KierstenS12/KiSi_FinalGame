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
    public Text endText;
    public Text lostText;
    private int count;
    private float timer;

    //audio stuff
    private AudioSource source;
    public AudioClip jumpClip;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    void Start()
    {
        count = 0;
        timer = 0;
        rb2d = GetComponent<Rigidbody2D>();
        announceText.text = "Quickly, Catch Five Tennis Balls!";
        endText.text = "";
        SetCountText();
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
        //This does a timer before ending the game after 10 seconds.
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));

        }

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
                source.PlayOneShot(jumpClip);
            }


        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KiSi_Ball"))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            SetCountText();
          // GameLoader.AddScore(10);
        }
    }
    void SetCountText()
    {
        //Check if we've collected all 10 pickups. If we have...
        if (count >= 10)
        {
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));
        }
      


    }
    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
       //GameLoader.gameOn = false;
    }
}
