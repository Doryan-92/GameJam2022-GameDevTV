using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
    {
    public int moveSpace = 2;
    public Transform playerMovePoint;
    [SerializeField] float speed = 10.0f;
    public bool gameOver = false;
    public LayerMask whatStopMovement;

    public Animator anim;


    void Start()
        {
        playerMovePoint.parent = null; //per definire che l'oggetto assegnato non � pi� un child
        }

    // Update is called once per frame
    void Update()
        {
        //Grid Movement
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerMovePoint.position) <= .05f)
            {
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f), .2f, whatStopMovement)) //Per controllare che non ci sia un ostacolo nella direzione voluta
                    {
                    playerMovePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f);
                    }

                }
            else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * moveSpace, 0f, 0f), .2f, whatStopMovement)) //Per controllare che non ci sia un ostacolo nella direzione voluta
                    {
                    playerMovePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * moveSpace, 0f, 0f);
                    }

                }
            //anim.SetBool("moving", false);
            }

    

        else
            {
            //anim.SetBool("moving", true);
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if(collision.CompareTag("Enemy"))
            {
            Debug.Log("Destroy that fucker!!!");
            }
        }

    }