using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MoveBasic : MonoBehaviour
{
    enum Direction
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    Direction direction = Direction.North;

    //sprites
    public Sprite NorthSprite;
    public Sprite SouthSprite;
    public Sprite EastSprite;
    public Sprite WestSprite;
    public Sprite NortheastSprite;
    public Sprite NorthWestSprite;
    public Sprite SouthEastSprite;
    public Sprite SouthWestSprite;

    public float mouseAngle { get; private set; }

    SpriteRenderer spriteRenderer;

    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;

    Vector3 difference;
    float DirectionRotation;

    bool canMove = true;

    Rigidbody2D player;
    public float runSpeed = 15f;

    float moveLimiter = 0.7f;

    // float direction = 1.0f;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Set the z-coordinate to 0 for 2D

        // Calculate the direction from the object to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the unsigned angle between the object's up vector and the direction vector
        float unsignedAngle = Vector2.Angle(Vector2.up, direction);

        // Calculate the signed angle to determine the direction of rotation
        float signedAngle = Vector2.SignedAngle(Vector2.up, direction);

        // Convert the signed angle to the range of 0 to 360 degrees
        if (signedAngle < 0)
        {
            mouseAngle = 360 + signedAngle;
        }
        else
        {
            mouseAngle = signedAngle;
        }

        GetDirection();

        SetSprite();

        Debug.Log(mouseAngle);
        //Debug.Log(signedAngle);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // animator.SetTrigger("swordAttack");
        }

        if (Input.GetKeyDown("space"))
        {
            player.velocity = player.velocity * player.mass;
        }
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;

            player.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        else
        {
            player.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        /*  Vector3 difference =
              Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
  
          difference.z = 0f;
  
          difference.Normalize();
  
          float DirectionRotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;*/

        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        //Dash
    }

    //if getinput leftkey then facing left and vice versa
    void GetDirection()
    {
        if (mouseAngle >= 350 && mouseAngle <= 10)
        {
            direction = Direction.North;
            Debug.Log("FaceNorth");
        }
        else if (mouseAngle >= 310 && mouseAngle <= 349)
        {
            direction = Direction.NorthEast;
            Debug.Log("FaceNorthEast");
        }
        else if (mouseAngle >= 230 && mouseAngle <= 309)
        {
            direction = Direction.East;
            Debug.Log("FaceEast");
        }
        else if (mouseAngle >= 191 && mouseAngle <= 229)
        {
            direction = Direction.SouthEast;
            Debug.Log("FaceSE");
        }
        else if (mouseAngle >= 170 && mouseAngle <= 190)
        {
            direction = Direction.South;
            Debug.Log("FaceSouth");
        }
        else if (mouseAngle >= 130 && mouseAngle <= 169)
        {
            direction = Direction.SouthWest;
            Debug.Log("FaceSouthWest");
        }
        else if (mouseAngle >= 50 && mouseAngle <= 129)
        {
            direction = Direction.West;
            Debug.Log("FaceWest");
        }
        else if (mouseAngle >= 10 && mouseAngle <= 49)
        {
            direction = Direction.NorthWest;
            Debug.Log("FaceNorthWest");
        }
    }

    /*
        {
            if (
                (
                    Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)
                    || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)
                )
            )
            {
                direction = Direction.NorthWest;
            }
            else if (
                (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)
            )
            {
                direction = Direction.NorthEast;
            }
            else if (
                (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)
            )
            {
                direction = Direction.SouthEast;
            }
            else if (
                (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)
            )
            {
                direction = Direction.SouthWest;
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction = Direction.North;
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                direction = Direction.East;
            }
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            {
                direction = Direction.South;
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                direction = Direction.West;
            }
        }*/

    void SetSprite()
    {
        if (direction == Direction.North)
        {
            spriteRenderer.sprite = NorthSprite;
        }
        else if (direction == Direction.NorthEast)
        {
            spriteRenderer.sprite = NortheastSprite;
        }
        else if (direction == Direction.East)
        {
            spriteRenderer.sprite = EastSprite;
        }
        else if (direction == Direction.SouthEast)
        {
            spriteRenderer.sprite = SouthEastSprite;
        }
        else if (direction == Direction.South)
        {
            spriteRenderer.sprite = SouthSprite;
        }
        else if (direction == Direction.SouthWest)
        {
            spriteRenderer.sprite = SouthWestSprite;
        }
        else if (direction == Direction.West)
        {
            spriteRenderer.sprite = WestSprite;
        }
        else if (direction == Direction.NorthWest)
        {
            spriteRenderer.sprite = NorthWestSprite;
        }

        void LockMovement()
        {
            canMove = false;
        }

        void UnlockMovement()
        {
            canMove = true;
        }
    }

    // Acceleration based movement

    /*
        private void FixedUpdate()
        {

            // player.AddForce(velocity * direction)


            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;

                // player.velocity = new Vector2(horizontal * runSpeed * player.mass, vertical * runSpeed * player.mass);

                fixedvelocity = new Vector2(horizontal * runSpeed * player.mass, vertical * runSpeed * player.mass);

                player.AddForce(fixedvelocity * player.mass);

            }

            else
            {

                fixedvelocity = new Vector2(horizontal * runSpeed * player.mass, vertical * runSpeed * player.mass);

                player.AddForce(fixedvelocity * player.mass);
            }
        }


        */
}
