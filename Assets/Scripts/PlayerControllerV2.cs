using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
    {
    public static PlayerControllerV2 Instance;

    [Header("Movement")]
    public int moveSpace = 2;
    public Transform playerMovePoint;
    [SerializeField] float speed = 10.0f;
    public LayerMask whatStopMovement;

    [Header("Game State")]
    public bool gameOver = false;

    [Header("Sound")]
    AudioSource audioSource;
    [SerializeField] AudioClip audioPoint;
    [SerializeField] AudioClip audioDamage;
    [SerializeField] AudioClip audioLife;

    private void Awake()
        {
        if (Instance != null)
            {
            Destroy(gameObject);
            return;
            }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        }

    void Start()
        {
        GameManager.Instance.health = 3;
        audioSource = GetComponent<AudioSource>();
        playerMovePoint.parent = null; //per definire che l'oggetto assegnato non è più un child
        }

    // Update is called once per frame
    void Update()
        {
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
        if (gameOver == false)
            {
            //Grid Movement
            if (Vector3.Distance(transform.position, playerMovePoint.position) <= .05f)
                {
                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                    {
                    if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f), .2f, whatStopMovement)) //Per controllare che non ci sia un ostacolo nella direzione voluta
                        {
                        playerMovePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpace, 0f);
                        }

                    }
                else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                    {
                    if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * moveSpace, 0f, 0f), .2f, whatStopMovement)) //Per controllare che non ci sia un ostacolo nella direzione voluta
                        {
                        playerMovePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * moveSpace, 0f, 0f);
                        }

                    }
                }


            }
        }
    private void OnTriggerEnter2D(Collider2D col)
        {
        if (col.CompareTag("Points"))
            {
            audioSource.PlayOneShot(audioPoint,0.5f);
            }


        }
    }