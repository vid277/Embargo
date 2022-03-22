using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scorevalue;
    /**
     * Sets the player score to the assigned value when the player is playing and set it to zero when the player is not playing.
     **/
    void Awake(){
        if (PlayerPrefs.HasKey("Score")){
            scorevalue.text = PlayerPrefs.GetString("Score");
        }
        else{
            scorevalue.text = "0";
        }
    }
    /**
     * Increases the player's score after they kill and enemy based on the score each enemy gives.
     **/
    void Update(){
        scorevalue.text = (Enemy.score).ToString();
        PlayerPrefs.SetString("Score", (Enemy.score).ToString());
    }
}
