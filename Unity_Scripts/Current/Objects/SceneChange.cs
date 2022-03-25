/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string scenename;
    public Vector2 positionofplayer;
    public Vectors playerobjectscriptable;
    public GameObject FadeInPanel;
    public GameObject FadeOutPanel;
    public float fadeWait;
    public FloatValue heartcont;
    public FloatValue playerCurrentHealth;


    /**
     * Creates the default scene
     **/
    private void Awake(){
        if(FadeInPanel != null){
            GameObject panel = Instantiate(FadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }   
    /**
     * Fades into a different scene when the player collides with the scene change collider
     * @param other This is the collider the player must contact to change the scene.
     **/
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            playerobjectscriptable.initialValue = positionofplayer;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(scenename);
        }
    }
    
    public IEnumerator FadeCo(){

        if (FadeOutPanel != null){
            Instantiate(FadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeWait);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scenename);

        while (!asyncOperation.isDone){ 
            yield return null;
        }
    }

}
