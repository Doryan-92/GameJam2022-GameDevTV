using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum GlyphType {Life, Damage, Point};
    [SerializeField] GlyphType glyphType;

    public int scoreToAdd;
    public int healthToAdd;
    public GameObject player;

    GameManager gameManager;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
        {
        if (col.CompareTag("Player"))
            {
        
            if(glyphType == GlyphType.Life)
                {
                if (gameManager.health < 3)
                    {
                    GameManager.Instance.UpLife(healthToAdd);
                    Destroy(gameObject);
                    }

                else if (gameManager.health == 3)
                    {
                    GameManager.Instance.UpdateScore(scoreToAdd);
                    Destroy(gameObject);
                    }
 
                }
          
            if (glyphType == GlyphType.Damage)
                {
                GameManager.Instance.DownLife(healthToAdd);
                Destroy(gameObject);
                }
           
            if (glyphType == GlyphType.Point)
                {
                GameManager.Instance.UpdateScore(scoreToAdd);
                Destroy(gameObject);
                }
            }
        }

    }
