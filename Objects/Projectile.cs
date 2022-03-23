using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed;
    public Vector2 direction;
    public float LifeTime;
    private float LifeTimeSeconds;

    void Start()
    {
        LifeTimeSeconds = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeSeconds -= Time.DeltaTime;
        if (LifeTimeSeconds <= 0){
            Destroy(this.gameObject);
        }
    }
}
