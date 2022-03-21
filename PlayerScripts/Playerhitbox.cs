using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhitbox : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("breakable")){
            other.GetComponent<pot>().destroy();
        }
        var move_comp = player.GetComponent<Player_move>();
        if (move_comp.currentState == PlayerState.stagger) {
            Debug.Log("YESYESYSEY");
            move_comp.StopPlayer();
        }
    }
}
