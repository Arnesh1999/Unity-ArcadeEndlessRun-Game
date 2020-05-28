using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardspeed;
    public float maxspeed;
    private int desiredLane = 1;
    public float laneDistance = 2.5f;
    public float jumpForce;
    public float gravity = -20;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardspeed;
        if(forwardspeed < maxspeed)
            forwardspeed += 0.1f * Time.deltaTime;


        if (controller.isGrounded)
        {
            direction.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
                SoundManagerScript.PlaySound("jump");
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
        
        if(SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
                desiredLane = 2;
            
            
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;


        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 movDir = diff.normalized * 25 * Time.deltaTime;
        if (movDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(movDir);
        else
            controller.Move(diff);
        


    }
    private void FixedUpdate()
    {

        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.deltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameover = true;

        }
    }
}
