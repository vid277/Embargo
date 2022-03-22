/* Creates a scriptable object that has tries, names, and scores

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Moves the camera to follow the player
public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    
    void Start()
    {
        
    }

    /**
     *  Update is called once per frame. The position of the camera changes to follow the camera so that the camera is always above the player
     * **/

    void LateUpdate() {
        if (transform.position != target.position){
            Vector3 targetpos = new Vector3 (target.position.x,
                                         target.position.y,
                                         transform.position.z);

            targetpos.x = Mathf.Clamp(targetpos.x, minPosition.x, maxPosition.x);
            targetpos.y = Mathf.Clamp(targetpos.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,
                                            targetpos,
                                            smoothing);
        }
        
    }
}
