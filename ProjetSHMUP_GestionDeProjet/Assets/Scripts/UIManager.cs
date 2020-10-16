using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hp;
    public Text score;
    public ship_controller player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hp <= 99)
        {
            hp.text = "" + player.hp;
        }
        else if(player.hp >= 99)
        {
            hp.text = "99+";
        }
        score.text = "Score: " + ScoreStore.score;
    }
}
