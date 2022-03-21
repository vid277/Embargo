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

    private void Awake(){
        if(FadeInPanel != null){
            GameObject panel = Instantiate(FadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Debug.Log("YES CALLED");
            Destroy(panel);
        }
    }   

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
