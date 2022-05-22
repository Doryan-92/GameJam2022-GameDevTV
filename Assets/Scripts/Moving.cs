using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
    {
    [SerializeField] Transform movePoint;
    float speed = 5.0f;

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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
StartCoroutine(ObjectMover(timeHold));
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
