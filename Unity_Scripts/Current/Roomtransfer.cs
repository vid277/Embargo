using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomtransfer : MonoBehaviour
{
    public Vector2 CamChange;
    public Vector3 playerChange;
    private CameraMove cam;
    
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
        if (other.CompareTag("Player")){
            cam.minPosition += CamChange;
            cam.maxPosition += CamChange;
            other.transform.position += playerChange;
        }
    }
}
