using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.8f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag ("Player").transform; // storing the information of the player position.
        offset = transform.position - lookAt.position;// this is used to move the camera a little behind from the player
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Moving the camera behind the player
        moveVector = lookAt.position + offset;//move the camera each frame according to the player
        //x
        moveVector.x = 0;// no movement of the camera horizontally
        //y
        moveVector.y = Mathf.Clamp(moveVector.y ,(float)5, (float)7); //clamps/sticks the value of the camera movement in the y axis to that certain point

       // animating the camera movement
        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);// lerping the camera from top to the bottom and sticking it
            transition += Time.deltaTime * 1 / animationDuration; //animating the camera movement according to the animationduration
            transform.LookAt(lookAt.position + Vector3.up);//to move the camera a little behind during the animation
        }
    
    }
}
