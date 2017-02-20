using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Bomb bomb;

    bool grounded;
    public bool flipped;
    public bool canWallJump = false;

    public Sprite walking;
    public Sprite jumping;
    public Sprite idle;


    KeyCode upKey;
    KeyCode rightKey;
    KeyCode leftKey;
    KeyCode bombKey;


    public enum SpriteState { WALKING_RIGHT, WALKING_LEFT, IDLE, JUMPING };
    public SpriteState state;
    // Use this for initialization
    void Start()
    {
        state = SpriteState.IDLE;
        flipped = false;

        if (tag == "Player1"){

            upKey = KeyCode.UpArrow;
            rightKey = KeyCode.RightArrow;
            leftKey = KeyCode.LeftArrow;
            bombKey = KeyCode.DownArrow;
        }
        else if (tag == "Player2") {

            upKey = KeyCode.W;
            rightKey = KeyCode.D;
            leftKey = KeyCode.A;
            bombKey = KeyCode.S;

        }
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case SpriteState.WALKING_RIGHT:
                //GetComponent<SpriteRenderer>().sprite = walking;
                GetComponent<Animator>().enabled = true;
                break;
            case SpriteState.WALKING_LEFT:
                //GetComponent<SpriteRenderer>().sprite = walking;
                GetComponent<Animator>().enabled = true;
                break;
            case SpriteState.JUMPING:
                GetComponent<Animator>().enabled = false;
                GetComponent<SpriteRenderer>().sprite = jumping;
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = idle;
                break;

        }

        if (Input.GetKeyDown(upKey) && grounded == true || Input.GetKeyDown(upKey) && canWallJump == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;

            if (Input.GetKey(rightKey))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 5), ForceMode2D.Impulse);
            }
            else if (Input.GetKey(leftKey))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 5), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }

            if (flipped)
            {
                Flip();
            }

            grounded = false;
            state = SpriteState.JUMPING;
            flipped = false;
            canWallJump = false;
        }

        if (Input.GetKey(rightKey) && grounded == true)
        {

            transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
            state = SpriteState.WALKING_RIGHT;
        }

        if (Input.GetKeyUp(rightKey) && grounded == true)
        {
            GetComponent<Animator>().enabled = false;
            state = SpriteState.IDLE;

        }

        if (Input.GetKey(leftKey) && grounded == true)
        {

            transform.Translate(Vector3.left * Time.deltaTime, Camera.main.transform);
            state = SpriteState.WALKING_LEFT;
            if (!flipped)
            {
                Flip();
            }
        }

        if (Input.GetKeyUp(leftKey) && grounded == true)
        {
            GetComponent<Animator>().enabled = false;
            if (flipped)
            {
                Flip();
            }
            state = SpriteState.IDLE;
            flipped = false;

        }

        if (Input.GetKeyDown(bombKey))
        {

            Bomb t = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 2f, 0), Quaternion.identity);
            t.parent = this;




        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Floor")
        {

            grounded = true;
            state = SpriteState.IDLE;

        }

        if (collision.collider.tag == "Wall")
        {

            canWallJump = true;
            GetComponent<Rigidbody2D>().gravityScale = .2f;


        }

    }

    void Flip()
    {


        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        flipped = true;
    }
}