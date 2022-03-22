/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roomtransfer : MonoBehaviour
{
    public Vector2 CamChange;
    public Vector3 playerChange;
    private CameraMove cam;
    public bool textRequired;
    public string textInput;
    public GameObject text;
    public Text placeText;
    public Text testbox;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
     *Transfers the player to a different area. Creates a x and y change value that teleports the player to the desired location.
     *@param other This is collider that the player must contact to trigger the transition. 
    **/
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            cam.minPosition += CamChange;
            cam.maxPosition += CamChange;
            other.transform.position += playerChange;
            if(textRequired){
                StartCoroutine(placeNameCo());
            }
        }
    }
    /**
     * Displays the name of zone the player has transfered too.
     * @return int This is the time that the name is displayed for.
     **/
    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = textInput;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
