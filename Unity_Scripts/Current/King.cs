/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField]
    public GameObject insertPrefab;
    [SerializeField]
    private float swarmerinterval = 5f;

/*Makes the king spawn enemys once every few seconds*/
    void Start(){
        StartCoroutine(spawnEnemy(swarmerinterval, insertPrefab));
    }

}
/*This enemy is unfinished*/