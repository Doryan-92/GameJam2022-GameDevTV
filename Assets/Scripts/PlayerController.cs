using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpingForce = 10.0f;
    Rigidbody2D playerRB;
    bool isOnGround = true;
    public bool gameOver = false;
    float gravityModifier;
    float fallTime;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        fallTime = 0;
        Physics.gravity *= gravityModifier;
        }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);


        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.DownArrow) && isOnGround && !gameOver)
            {
            isOnGround = false;
            playerRB.AddForce(Vector3.up * jumpingForce, ForceMode2D.Impulse);
            }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space) && isOnGround)
            {
       
            gameObject.GetComponent<Collider2D>().enabled = false;
            if(fallTime == 0)
                {
                fallTime += Time.deltaTime;

                }
            else if(fallTime >= 1) //non funziona
                {
                Debug.Log("collider enabled!");
                gameObject.GetComponent<Collider2D>().enabled = true;
                fallTime = 0;
                }


            }

        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.CompareTag("Ground"))
            {
            isOnGround = true;
            }
        else if (collision.gameObject.CompareTag("Obstacle"))
            {
            Debug.Log("Game Over!");
            gameOver = true;

            }
        }
    }
