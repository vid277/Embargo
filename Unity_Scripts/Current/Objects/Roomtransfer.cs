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

    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = textInput;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
