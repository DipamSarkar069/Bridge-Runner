using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    public CharacterController controller; //to access the Character Controller from the game components
    private Vector3 moveVector; // to access the vector elements(x,y,z) for the movements 

    private float animationDuration = 2.8f;

    public float speed = 25.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private bool isDead = false;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // To initialise the component into controller
        startTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead)
        {
        return;
        }
        //to stop the controls during the animation period
        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward*speed*Time.deltaTime);
            return;
        }

        //the control starts
        moveVector = Vector3.zero; //updates in each frame and reset the Vector components
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity-=gravity*Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal")*speed; // to move the player sideways
        if(Input.GetMouseButton(0))
        {
            //holding touch on the right side
            if(Input.mousePosition.x >Screen.width/2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
        }

        moveVector.z = speed; // to move the player forward
        moveVector.y = verticalVelocity;

        controller.Move(moveVector*Time.deltaTime);//the final action of movement

    
    }

    //modifies the speed and adds difficulty to the level which is called in 'Score' Script
    public void SetSpeed(float modifier)
    {
        speed = 25.0f + modifier;
    }

    //it is called everytime our player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.y > transform.position.y + controller.radius)
        {
            Death();
        }
    }

    //Shows the score in the Death Menu when the Player Collides
    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}
