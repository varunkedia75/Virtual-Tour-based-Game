using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float runningSpeed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    public Transform Player;
 
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = runningSpeed;
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 6.0f;
            }
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}