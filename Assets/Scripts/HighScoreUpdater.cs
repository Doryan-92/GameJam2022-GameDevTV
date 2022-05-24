using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class HighScoreUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameManager.Instance.highScoreText.text = "" + GameManager.highScore + "";
        }

}
