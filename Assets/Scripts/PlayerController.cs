using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController Instance;

    public enum playerStates { Down_Walking, Right_Walking, up_Walking, Left_Walking, AntiGravity }

    public playerStates CurrentState;

    public float movingSpeed;
    public float jumpForce;
    private float moveInput;

    [SerializeField] float flyingForce;
    [SerializeField] float forwardForce;

    private float Move;

    private bool facingRight = false;
    [HideInInspector]
    public bool deathState = false;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    [SerializeField] bool canDoubleJump;
    bool isJumped;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    // private GameManager gameManager;
    public bool isDead;
    Vector3 LastCheckPointPo;
    private void Awake()
    {
        if (Instance != null)
        {
          //  Destroy(gameObject);
        }
        else
        {
            Instance = this;

           // DontDestroyOnLoad(gameObject);

        }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //  transform.position = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (AudioManager.Instance.ShouldRespawn)
        {
            Respawn();
        }
       // AudioManager.Instance.ShouldRespawn = true;
    }

    void Respawn()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY")) + new Vector2(0.5f,0);
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {

        if (!isDead)
        {
            switch (CurrentState)
            {
                case playerStates.Down_Walking:
                    Physics2D.gravity = new Vector2(0, -9.81f);
                    if (Input.GetKey(KeyCode.D))                         //Movement code
                    {
                        // theRb.AddForce(Vector2.right);
                        Move = 1;

                        transform.localScale = new Vector2(1, 1);



                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        // theRb.AddForce(Vector2.left);
                        Move = -1;
                        transform.localScale = new Vector2(-1, 1);
                    }
                    else
                    {

                        Move = 0;
                        // stopMoving();
                        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                        // Move = Mathf.Lerp(Move, 0, 2f);


                    }
                    rigidbody2d.velocity = new Vector2(movingSpeed * Move * Time.fixedDeltaTime, rigidbody2d.velocity.y);



                    if (isGrounded && !Input.GetButton("Jump"))
                    {
                        canDoubleJump = false;


                    }
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (isGrounded || canDoubleJump)
                        {
                            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);

                            canDoubleJump = !canDoubleJump;

                            AudioManager.Instance.PlaySfx(1);

                        }

                    }

                    break;

                case playerStates.Right_Walking:
                    Physics2D.gravity = new Vector2(9.81f, 0);
                    if (Input.GetKey(KeyCode.D))                         //Movement code
                    {
                        // theRb.AddForce(Vector2.right);
                        Move = 1;
                        transform.localScale = new Vector2(1, 1);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        // theRb.AddForce(Vector2.left);
                        Move = -1;
                        transform.localScale = new Vector2(-1, 1);
                    }
                    else
                    {

                        Move = 0;
                        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
                        // Move = Mathf.Lerp(Move, 0, 2f);


                    }
                    // rigidbody2d.velocity = new Vector2(movingSpeed * Move * Time.fixedDeltaTime, rigidbody2d.velocity.y);

                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, movingSpeed * Move * Time.fixedDeltaTime);



                    if (isGrounded && !Input.GetButton("Jump"))
                    {
                        canDoubleJump = false;


                    }
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (isGrounded || canDoubleJump)
                        {
                            rigidbody2d.velocity = new Vector2(-jumpForce, rigidbody2d.velocity.y);

                            canDoubleJump = !canDoubleJump;
                            AudioManager.Instance.PlaySfx(1);
                        }

                    }

                    break;

                case playerStates.up_Walking:

                    Physics2D.gravity = new Vector2(0, 9.81f);

                    if (Input.GetKey(KeyCode.D))                         //Movement code
                    {
                        // theRb.AddForce(Vector2.right);
                        Move = -1;
                        transform.localScale = new Vector2(1, 1);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        // theRb.AddForce(Vector2.left);
                        Move = 1;
                        transform.localScale = new Vector2(-1, 1);
                    }
                    else
                    {

                        Move = 0;
                        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                        // Move = Mathf.Lerp(Move, 0, 2f);


                    }
                    // rigidbody2d.velocity = new Vector2(movingSpeed * Move * Time.fixedDeltaTime, rigidbody2d.velocity.y);

                    rigidbody2d.velocity = new Vector2(movingSpeed * Move * Time.fixedDeltaTime, rigidbody2d.velocity.y);



                    if (isGrounded && !Input.GetButton("Jump"))
                    {
                        canDoubleJump = false;


                    }
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (isGrounded || canDoubleJump)
                        {
                            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -jumpForce);

                            canDoubleJump = !canDoubleJump;

                            AudioManager.Instance.PlaySfx(1);
                        }

                    }


                    break;
                case playerStates.Left_Walking:

                    Physics2D.gravity = new Vector2(-9.81f, 0);
                    if (Input.GetKey(KeyCode.D))                         //Movement code
                    {
                        // theRb.AddForce(Vector2.right);
                        Move = -1;
                        transform.localScale = new Vector2(1, 1);
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        // theRb.AddForce(Vector2.left);
                        Move = 1;
                        transform.localScale = new Vector2(-1, 1);
                    }
                    else
                    {

                        Move = 0;
                        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
                        // Move = Mathf.Lerp(Move, 0, 2f);


                    }
                    // rigidbody2d.velocity = new Vector2(movingSpeed * Move * Time.fixedDeltaTime, rigidbody2d.velocity.y);

                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, movingSpeed * Move * Time.fixedDeltaTime);



                    if (isGrounded && !Input.GetButton("Jump"))
                    {
                        canDoubleJump = false;


                    }
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (isGrounded || canDoubleJump)
                        {
                            rigidbody2d.velocity = new Vector2(jumpForce, rigidbody2d.velocity.y);

                            canDoubleJump = !canDoubleJump;

                            AudioManager.Instance.PlaySfx(1);

                        }

                    }

                    break;


                case playerStates.AntiGravity:

                    rigidbody2d.velocity = new Vector2(forwardForce, rigidbody2d.velocity.y);

                    if (Input.GetKey(KeyCode.Space))
                    {

                        //  rigidbody2d.AddForce(transform.up * flyingForce * Time.deltaTime);
                        animator.SetBool("isGrounded", true);
                        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, flyingForce);

                    }
                    else
                    {
                        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -flyingForce);
                        animator.SetBool("isGrounded", false);
                    }

                    //if (Input.GetKey(KeyCode.LeftArrow))
                    //{
                    //    transform.Rotate(Vector3.forward * 10 * Time.deltaTime);

                    //}









                    break;

            }

            if (Input.GetButtonUp("Jump") && rigidbody2d.velocity.y > 0f)
            {
                // rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * 0.5f);
            }

            if (Move == 1 || Move == -1)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (CurrentState != playerStates.AntiGravity)
            {
                animator.SetBool("isGrounded", isGrounded);
            }




        }




    }



    public void ResetPlayer()
    {
        DownWalking();
        gameObject.SetActive(true);
        
    }
    public void stopMoving()
    {
        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);

        // Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, groundCheckRadius);

        // isGrounded = colliders.Length > 1;
    }
    public float lookRadius = 10f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }

    public void OnJumpDown()
    {
        if (isGrounded && !isJumped)
        {
            // CreateDust();
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            canDoubleJump = true;
            //  canDash = true;

        }
        else
        {
            if (canDoubleJump && !isGrounded && isJumped)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
                canDoubleJump = false;
                isJumped = false;
                //  canDash = true;

            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            deathState = true; // Say to GameManager that player is dead
        }
        else
        {
            deathState = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            // gameManager.coinsCounter += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("DownRight"))
        {
            if (CurrentState == playerStates.Down_Walking)
            {
                RightWalking();
            }
            else
            {
                DownWalking();
            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("RightUp"))
        {
            if (CurrentState == playerStates.Right_Walking)
            {
                UpWalking();

            }
            else
            {
                if (CurrentState == playerStates.up_Walking)
                {
                    RightWalking();

                }

            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("UpLeft"))
        {
            if (CurrentState == playerStates.up_Walking)
            {
                LeftWalking();

            }
            else
            {
                if (CurrentState == playerStates.Left_Walking)
                {
                    UpWalking();

                }

            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("LeftDown"))
        {
            if (CurrentState == playerStates.Left_Walking)
            {
                DownWalking();

            }
            else
            {
                if (CurrentState == playerStates.Down_Walking)
                {
                    LeftWalking();

                }

            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("RightDown"))
        {
            if (CurrentState == playerStates.Right_Walking)
            {
                DownWalking();
                if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                {
                    // rigidbody2d.position = other.GetComponent<WallWalker>().Pos1.position;
                    //  rigidbody2d.MovePosition(other.GetComponent<WallWalker>().Pos1.position);
                    transform.position = other.GetComponent<WallWalker>().Pos1.position;

                }
            }
            else
            {
                if (CurrentState == playerStates.Down_Walking)
                {
                    RightWalking();
                    if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                    {
                        transform.position = other.GetComponent<WallWalker>().Pos2.position;

                    }
                }

            }

            AudioManager.Instance.PlaySfx(2);
        }
        if (other.gameObject.CompareTag("DownLeft"))
        {
            if (CurrentState == playerStates.Down_Walking)
            {
                LeftWalking();
                if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                {
                    transform.position = other.GetComponent<WallWalker>().Pos1.position;
                    // transform.position = other.GetComponent<WallWalker>().Pos1.position;

                }
            }
            else
            {
                if (CurrentState == playerStates.Left_Walking)
                {
                    DownWalking();
                    if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                    {
                        transform.position = other.GetComponent<WallWalker>().Pos2.position;
                        // transform.position = other.GetComponent<WallWalker>().Pos2.position;
                    }
                }

            }
            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("LeftUp"))
        {
            if (CurrentState == playerStates.Left_Walking)
            {
                UpWalking();
                if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                {
                    transform.position = other.GetComponent<WallWalker>().Pos1.position;


                }
            }
            else
            {
                if (CurrentState == playerStates.up_Walking)
                {
                    LeftWalking();
                    if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                    {
                        transform.position = other.GetComponent<WallWalker>().Pos2.position;

                    }
                }

            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("UpRight"))
        {
            if (CurrentState == playerStates.up_Walking)
            {
                RightWalking();
                if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                {
                    transform.position = other.GetComponent<WallWalker>().Pos1.position;


                }
            }
            else
            {
                if (CurrentState == playerStates.Right_Walking)
                {
                    UpWalking();
                    if (other.gameObject.GetComponent<WallWalker>().Pos1 != null)
                    {
                        transform.position = other.GetComponent<WallWalker>().Pos2.position;

                    }
                }

            }

            AudioManager.Instance.PlaySfx(2);
        }

        if (other.gameObject.CompareTag("AntiGravity"))
        {
            if (CurrentState == playerStates.Down_Walking)
            {
                CurrentState = playerStates.AntiGravity;
            }

        }

        if (other.gameObject.CompareTag("AntiGravityEnd"))
        {
            if (CurrentState == playerStates.AntiGravity)
            {
                DownWalking();
            }

        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AntiGravityEnd"))
        {
            if (CurrentState == playerStates.AntiGravity)
            {
                DownWalking();
            }

        }
    }

    private void LeftWalking()
    {
        Physics2D.gravity = new Vector2(-9.81f, 0);
        CurrentState = playerStates.Left_Walking;

        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    private void DownWalking()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
        CurrentState = playerStates.Down_Walking;

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void RightWalking()
    {
        Physics2D.gravity = new Vector2(9.81f, 0);
        CurrentState = playerStates.Right_Walking;
        // transform.Rotate(new Vector3(0, 0, 90));
        transform.rotation = Quaternion.Euler(0, 0, 90);
        // Quaternion rotation = Quaternion.Euler(0, 30, 0);
    }

    private void UpWalking()
    {
        Physics2D.gravity = new Vector2(0, 9.81f);
        CurrentState = playerStates.up_Walking;

        transform.rotation = Quaternion.Euler(0, 0, 180);
    }




}