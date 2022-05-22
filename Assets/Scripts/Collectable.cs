using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum GlyphType {Life, Damage, Point};
    [SerializeField] GlyphType glyphType;
    [SerializeField] GameObject player;
    public int scoreToAdd;

    PlayerControllerV2 playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerV2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if(collision.CompareTag("Player"))
            {
            Debug.Log("Collided!");
            if(glyphType == GlyphType.Life)
                {
                if (playerController.health < 3)
                    {
                    playerController.health++;
                    }
                else
                    {
                    playerController.points += scoreToAdd;
                    }
                Destroy(gameObject);
                }
          
            if (glyphType == GlyphType.Damage)
                {
                playerController.health--;
                Destroy(gameObject);
                }
           
            if (glyphType == GlyphType.Point)
                {
                playerController.points += scoreToAdd;
                Destroy(gameObject);
                }
            }
        }
    }
