using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    public bool facingRight;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;
    bool isGrounded = false;

    [Header("Slope Check")]
    [SerializeField] private float slopeCheckDistance;
    [SerializeField] private float maxSlopeAngle;

    [Header("Player Slope Physics")]
    [SerializeField] private PhysicsMaterial2D noFriction;
    [SerializeField] private PhysicsMaterial2D infinteFriction;

    //--Private Variables
    private Animator anim;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D cc;

    private float xInput;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private float slopeSideAngle;

    private int slopeDownConditions = 3;

    private bool isOnSlope;
    private bool canJump;
    private bool isJumping;
    private bool canWalkOnSlope;

    private Vector2 newForce;
    private Vector2 newVelocity;
    private Vector2 colliderSize;

    private Vector2 slopeNormalPrep;

    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider2D>();

        colliderSize = cc.size;
    }

    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        SlopeCheck();
        ApplyMovement();
    }


    // Use Update for quick response from inputs (using older input system)
    void CheckInput()
    {
        // Grabs horizontal inputs (A,D,Left Arrow,Right Arrow keys)
        xInput = Input.GetAxis("Horizontal");

        // Allows player to move along the x-axis every frame * movement speed (public variable)
        transform.position += new Vector3(xInput, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        SpriteAnimation();
        SpriteFlip();
    }

    void Jump()
    {
        if (canJump)
        {
            canJump = false;
            isJumping = true;
            anim.SetBool("IsJumping", true);
            newVelocity.Set(0.0f, 0.0f);
            rb2d.velocity = newVelocity;
            newForce.Set(0.0f, JumpForce);
            rb2d.AddForce(newForce, ForceMode2D.Impulse);
        }
    }

    // Sprite flip is more reliable using rotation than scale for player
    void SpriteFlip()
    {
        if((xInput < 0 && facingRight) || (xInput > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    // Set animation
    void SpriteAnimation()
    {
        // Set the yVelocity in the animator
        anim.SetFloat("yVelocity", rb2d.velocity.y);

        // Set the Speed float in the animator
        anim.SetFloat("Speed", Mathf.Abs(xInput));
    }

    // Check if player is on slope - Use FixedUpdate
    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);

        SlopeCheckHorizontal(checkPos);
        SlopeCheckVertical(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, groundLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, groundLayer); ;

        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, groundLayer);

        if (hit)
        {
            slopeNormalPrep = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPrep, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }

        if (slopeDownAngle > maxSlopeAngle || slopeSideAngle > maxSlopeAngle)
        {
            canWalkOnSlope = false;
        }
        else
        {
            canWalkOnSlope = true;
        }

        if (isOnSlope && xInput == 0.0f && canWalkOnSlope)
        {
            rb2d.sharedMaterial = infinteFriction;
        }
        else
        {
            rb2d.sharedMaterial = noFriction;
        }
    }

    // Checks if player is on the ground
    // Use FixedUpdate to check several times per frame if isGrounded is true/false
    void GroundCheck()
    {
        //--This is new code needed for slope check
        isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheckRadius, groundLayer);

        if (rb2d.velocity.y <= 0.0f)
        {
            isJumping = false;
        }

        if (isGrounded && !isJumping && slopeDownAngle <= maxSlopeAngle)
        {
            anim.SetBool("IsJumping", !isGrounded);
            canJump = true;
        }


        //--This code is makes animations smoother for jump and fall for some reason
        //--even if it's redundent
        isGrounded = false;
        
        /* Checks if the GroundCheckObject is colliding with
        // 2D Colliders that are in the "Ground" layer
        If yes (isGrounded true) else (is Grounded false)*/

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0) // checks 2Dcollider's radius for the ground layer
            isGrounded = true;
        /* As long as we are grounded the "IsJumping" bool
        in the animator is disabled */
        anim.SetBool("IsJumping", !isGrounded);

    }

    void ApplyMovement()
    {
        //--Need to set initial velocity in order for the character movement to function
        newVelocity.Set(MovementSpeed * xInput, rb2d.velocity.y);
        rb2d.velocity = newVelocity;

        //--Set of conditions when player is on slope
        //--applies force to player perp of slope
        switch (slopeDownConditions)
        {
            case 1:
                if (isGrounded && !isOnSlope)
                    newVelocity.Set(MovementSpeed * xInput, 0.0f);
                rb2d.velocity = newVelocity;
                break;
            case 2:
                if (isGrounded && isOnSlope && !isJumping && canWalkOnSlope)
                    newVelocity.Set(MovementSpeed * slopeNormalPrep.x - xInput, MovementSpeed * slopeNormalPrep.y * -xInput);
                rb2d.velocity = newVelocity;
                break;
            case 3:
                if (!isGrounded)
                    newVelocity.Set(MovementSpeed * xInput, rb2d.velocity.y);
                rb2d.velocity = newVelocity;
                break;
            default:
                Debug.LogError("DownSlopeSwitch is Broken!");
                break;
        }
    }

}
