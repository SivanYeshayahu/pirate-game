using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
   // public Text text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    // Update is called once per frame
    public void changeScore(int coinValue)
    {
        score = score + coinValue;
        // score += coinValue;
        text.text = "X" + score.ToString();
    }
}
