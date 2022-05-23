using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
    {
    public GameObject movePointGameObject;
    [SerializeField] Transform movePoint;
    float speed = 5.0f;
    float xBorder = 12;


    public float timeHold = 2;
    bool onPos;

    PlayerControllerV2 playerController;


    // Start is called before the first frame update
    void Start()
        {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
        movePoint.parent = null;
        onPos = true;
        }

    // Update is called once per frame
    void Update()
        {
        if (transform.position.x < -xBorder)
            {
            Destroy(gameObject);
            Destroy(movePointGameObject);
            }
        if(playerController.gameOver == false)
            {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
            StartCoroutine(ObjectMover(timeHold));
            }

        }



   IEnumerator ObjectMover(float timehold)
        {
        while (Vector3.Distance(transform.position, movePoint.position) == 0 && !playerController.gameOver && onPos)
            {
            onPos = false;
            movePoint.position += new Vector3(-playerController.moveSpace, 0f, 0f);
            yield return new WaitForSeconds(timehold);
            onPos = true;
            }


        }

    }
