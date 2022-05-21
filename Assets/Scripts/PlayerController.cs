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


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        Physics.gravity *= gravityModifier;
        }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
            isOnGround = false;
            playerRB.AddForce(Vector3.up * jumpingForce, ForceMode2D.Impulse);
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
