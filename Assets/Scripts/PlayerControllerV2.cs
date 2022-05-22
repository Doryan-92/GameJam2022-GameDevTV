using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
    {
    public float verticalInput;
    int moveSpace = 2;
    public Transform movePoint;
    [SerializeField] float speed = 10.0f;
    public bool gameOver = false;
    public LayerMask whatStopMovement;


    void Start()
        {
        movePoint.parent = null; //per definire che l'oggetto assegnato non è più un child
        }

    // Update is called once per frame
    void Update()
        {
        //Grid Movement
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f), .2f, whatStopMovement)) //Per controllare che non ci sia un ostacolo nella direzione voluta
                    {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f);
                    }
          
                }
            }
        }
    }