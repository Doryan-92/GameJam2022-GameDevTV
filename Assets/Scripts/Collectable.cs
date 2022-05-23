using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum GlyphType {Life, Damage, Point};
    [SerializeField] GlyphType glyphType;
    public int scoreToAdd;
    public int healthToAdd;

    PlayerControllerV2 playerController;
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if(collision.CompareTag("Player"))
            {
            if(glyphType == GlyphType.Life)
                {
                if (gameManager.health < 3)
                    {
                    gameManager.UpLife(healthToAdd);
                    Destroy(gameObject);
                    }

                else if (gameManager.health == 3)
                    {
                    gameManager.UpdateScore(scoreToAdd);
                    Destroy(gameObject);
                    }
 
                }
          
            if (glyphType == GlyphType.Damage)
                {
                gameManager.DownLife(healthToAdd);
                Destroy(gameObject);
                }
           
            if (glyphType == GlyphType.Point)
                {
                gameManager.UpdateScore(scoreToAdd);
                Destroy(gameObject);
                }
            }
        }
    }
