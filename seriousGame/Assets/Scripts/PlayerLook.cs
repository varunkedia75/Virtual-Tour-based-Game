///<header>
///Module:            PlayerLook
///Date of Creation : 07-04-18
///Author:			  Mukul Verma
///Modification history: 
///     07-04-18  :  Created module and functionality to control the movements of the camera of the player.
///Synopsis:
///        This module controls the camera movements when the player moves the mouse , accordingly.
///Global Variable:
///        public Transform playerBody;
///        public float mouseSensitivity;
///Functions:
///        void Awake()
///        void Update()
///        void RotateCamera()
///</header>

//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{   

    //Declaration of Global variables from the Unity Studio.
    public Transform playerBody;                                    
    public float mouseSensitivity;                                                              //mouse sensitivity decides how much to rotate camera depending on the movement of mouse

    float xAxisClamp = 0.0f;                                                                    //to see  at 90 and -90 degree (i.e. exactly abouve and below)  of the player


    /// <summary>
    ///         Initialize the instance when game loads.
    /// </summary>
    void Awake()
    {       
        Cursor.lockState = CursorLockMode.Locked;                                               //the cursor dissappears as the game from the screen begins. 
    }

    /// <summary>
    ///         Load the instance per frame.
    /// </summary>
    void Update()
    {
        RotateCamera();
    }


    /// <summary>
    ///         manages the camera rotation when player moves the mouse.    
    /// </summary>
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");                                                //get the movement of mouse in 'x' direction
        float mouseY = Input.GetAxis("Mouse Y");                                                //get the movement of mouse in 'y' direction

        float rotAmountX = mouseX * mouseSensitivity;                                           //get the effective movement by multiplying with mouse sensitivity.
        float rotAmountY = mouseY * mouseSensitivity;                                           

        xAxisClamp -= rotAmountY;                                                               //getting how camera rotated in x axis.(as in unity by y rotation of mouse we get -ve rotation in x)

        Vector3 targetRotCam = transform.rotation.eulerAngles;                                  //declaration of  a rotation vector for camera.
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;                                //declaration of a rotation vector for player body.

        targetRotCam.x -= rotAmountY;                                                           //In unity +ve y movement of mouse gives the -ve x movement so decrease by y movement so that we get positive rotation in x.
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;                                                          //In unity +ve x movement of mouse gives the +ve y movement so increase by x movement so that we get positive rotation in y

        //Check if player is looking vertically above the body or not
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;                                                                //set the rotation of camera to 90 so that player can not rotate further (as a body cannot move head beyond 90 vertically up)
        }
        //check if player is looking vertivally down the body or not
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;                                                              //set the rotation of camera to 270 so that player can not rotate further (as a body cannot move head beyond 90 vertically down)
        }

        print(mouseY);

            
        transform.rotation = Quaternion.Euler(targetRotCam);                                   //convert the euler angler back to quaternion and rotate the camera accordingly
        playerBody.rotation = Quaternion.Euler(targetRotBody);                                 //convert the euler angler back to quaternion and rotate the body accordingly
    }
    /************* END OF CLASS ***********/
}
