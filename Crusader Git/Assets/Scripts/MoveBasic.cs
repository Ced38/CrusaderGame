using System.Collections;
using System.Collections.Generic;
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
    public Sprite Northeast;
    public Sprite NorthWest;
    public Sprite SouthEast;
    public Sprite SouthWest;

    SpriteRenderer spriteRenderer;

    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;

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

        GetDirection();

        SetSprite();

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

        //Dash
    }

    //if getinput leftkey then facing left and vice versa
    void GetDirection()
    // Could add  && Input.GetKeyDown(KeyCode.A) to every one to ensure keys are still being pressed


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
    }

    void SetSprite()
    {
        if (direction == Direction.North)
        {
            spriteRenderer.sprite = NorthSprite;
        }
        else if (direction == Direction.South)
        {
            spriteRenderer.sprite = SouthSprite;
        }
        else if (direction == Direction.East)
        {
            spriteRenderer.sprite = EastSprite;
        }
        else if (direction == Direction.West)
        {
            spriteRenderer.sprite = WestSprite;
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
