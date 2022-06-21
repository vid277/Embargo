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
    public static List<string> namesstore = new List<string>();
    public string usernames1;
    public string usernames2;
    public string score1;
    public string score2;
    public int tries;
    public static List<Userscore> ScoreList = new List<Userscore>();
    
    private void Update() {
        score1 = Int32.Parse(PlayerPrefs.GetString("Score"));
        usernames1 = PlayerPrefs.GetString("UsernameP1"); 
        UserScore onescore = new UserScore(usernames1, score1);
        ScoreList.Add(onescore);
    }

    public List<Userscore> sortscore() {
        return ScoreList.Sort((a,b) => Int.Compare(a.score, b.score)*-1);

    }
    
    void Awake() {
        tries = Int32.Parse(PlayerPrefs.GetString("Tries"));

        if (!showscore.activeInHierarchy){
            showscore.SetActive(true);
        }

        StartCoroutine(someco());



    //How to use sort list
        List<UserScore> SortedScoreList = sortScore();

    /**
        tries = MenuScreen.Numberoftries; 
        if (PlayerPrefs.HasKey("UsernameP1")){
                usernames1 = PlayerPrefs.GetString("UsernameP1");
                namesstore.Add(usernames1);
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
    **/
    void storescore(){  
        //sortScore();
        if(tries <= 6){
            for (int i = 0; i < tries; i++){
                names[i].text = namesstore[i];
                scores[i].text = scorestore[i];
            }
        }
    }
    /**
    void sortScore(){
         String temp;
         for (int j = 0; j < scorestore.Count - 1; j++) {
            for (int i = 0; i < scorestore.Count - j - 1; i++) {
               if (Int32.Parse(scorestore[i]) > Int32.Parse(scorestore[i + 1])) {
                  temp = scorestore[i + 1];
                  scorestore[i] = scorestore[i + 1];
                  scorestore[i + 1] = temp;
               }
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
        yield return new WaitForSeconds(3f);
        showscore.SetActive(false);
    }
    **/
}