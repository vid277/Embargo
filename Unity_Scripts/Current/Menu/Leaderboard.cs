using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Leaderboard : MonoBehaviour
{
    public float speed;
    public string texttype;
    public string currenttyping = "";
    public Text textbox;
    public Text scoreshower;
    public GameObject showscore;
    //Leaderboard
    public List<Text> scores = new List<Text>();
    public List<Text> names = new List<Text>();
    public static List<string> scorestore = new List<string>();
    public string usernames1;
    public string usernames2;
    public string score1;
    public string score2;
    public int tries;
    
    private void Update() {
        score1 = PlayerPrefs.GetString("Score");
    }

    void Awake() {

        if (!showscore.activeInHierarchy){
            showscore.SetActive(true);
        }

        StartCoroutine(someco());

        tries = MenuScreen.Numberoftries; 
        if (PlayerPrefs.HasKey("UsernameP1")){
                usernames1 = PlayerPrefs.GetString("UsernameP1");
                if (PlayerPrefs.HasKey("Score")){
                    score1 = PlayerPrefs.GetString("Score");
                    scorestore.Add(score1.ToString());
                    storescore();
                }
        }

        if (MenuNameStorage.multiplayer){
            //change
            if (PlayerPrefs.HasKey("UsernameP2")){
                usernames2 = PlayerPrefs.GetString("UsernameP2");
                if (PlayerPrefs.HasKey("Score")){
                        //change
                    score2 = PlayerPrefs.GetString("Score");
                    storescore();
                }
            }
        }
    }

    void storescore(){  
        if(tries <= 6){
            for (int i = 0; i <= tries; i++){
                names[i].text = usernames1;
                scores[i].text = scorestore[i];
            }
        }
    }

    public IEnumerator someco(){
        for(int i = 0; i < texttype.Length; i++){
            currenttyping = texttype.Substring(0,i);
            textbox.text = currenttyping;
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1.5f);
        scoreshower.text = score1.ToString();
        yield return new WaitForSeconds(5f);
        showscore.SetActive(false);
    }
}
