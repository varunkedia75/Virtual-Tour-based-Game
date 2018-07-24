///<header>
///Module:            checkpoint
///Date of Creation : 06-04-18
///Author:			Mukul Verma
///Modification history: 
///     13-04-18  :  Created module and functionality to show that the player is reached at a checkpoint.
///Synopsis:
///         The module takes the list of checkpoints from the database and check if player is in the 10f radius of the checkpoint.
///         If player is in the 10f radius of checkpoint , it activates the canvas which shows that message "Checkpoint" which
///         means player is reached at the checkpoint.It also stores the game data like time left and destination in the prefs( that is a database from UnityEngine module ).   
///Global Variables:
///       public Transform player;
///       public Transform Canvas;
///Functions:
///         void Start()
///         void Update()
///         IEnumerator Wait()
///</header>

// imports required from the UnityEngine module
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{


    //Declaration of global variable from unity studio
    public Transform player;                                                    //instance of player.
    public Transform Canvas;                                                    //canvas which shows the message 'Checkpoint'.

    //Declaration of private variable used in the class
    private float xpos;                                                         //variable  to store 'x' coordinates of current position of player in the gameplay.
    private float ypos;                                                         //variable  to store 'y' coordinates of cuurent position of player in the gameplay.
    private float zpos;                                                         //variable  to store 'z' coordinates of current position of player in the gameplay.
    private float checkPointPosX;                                               //variable  to store 'x' coordinates of checkpoint. 
    private float checkPointPosY;                                               //variable  to store 'y' coordinates of checkpoint.
    private float checkPointPosZ;                                               //variable  to store 'z' coordinates of checkpoint.



    /// <summary>
    ///     Below function loads the instance  when the  first frame loads.
    /// </summary>
    void Start()
    {
        Canvas.gameObject.SetActive(false);                                     //deactivate the canvas 
    }


    /// <summary>
    ///        Update this instance,once a frame.
    /// </summary>
    void Update()
    {
        xpos = player.transform.position.x;                                     //get the 'x' coordinate of  current position of player.
        ypos = player.transform.position.y;                                     //get the 'y' coordinate of  current position of player.
        zpos = player.transform.position.z;                                     //get the 'z' coordinate of  current position of player.

        for (int i = 0; i < 3; i++)                                 
        {
            checkPointPosX = database.checkPoints[i, 0];                        //get the 'x'  coordinate of checkpoint.
            checkPointPosY = database.checkPoints[i, 1];                        //get the 'y'  coordinate of checkpoint.
            checkPointPosZ = database.checkPoints[i, 2];                        //get the 'z'  coordinate of checkpoint.


            //check if player reached in 10f radius of a checkpoint
            if ( ( xpos > (checkPointPosX - 10) &&  xpos <  (checkPointPosX + 10)) && (ypos > (checkPointPosY - 10)  &&  ypos < (checkPointPosY + 10)) && (zpos > (checkPointPosZ - 10) &&  zpos < (checkPointPosZ + 10) ))
            {
                Canvas.gameObject.SetActive(true);                              //activate the canvas. 
                PlayerPrefs.SetFloat("positionX", xpos);                        //store the 'x' cordinate current position of player.
                PlayerPrefs.SetFloat("positionY", ypos);                        //store the 'y' cordinate current position of player.
                PlayerPrefs.SetFloat("positionZ", zpos);                        //store the 'z' cordinate current position of player.
                PlayerPrefs.SetFloat("time", timer.timeLeft);                   //store the time left for the game.
                PlayerPrefs.SetInt("destinationIndex", destination.index);      //store the destination. 
                destination.checkPreviousDestination = true;                    //make the bool(extern , loaded from destination module) true which shows that now checkfordestionation from the stored location when player resumes.
                StartCoroutine(Wait());                                         //call for another routine
                
            }
        }

    }


    /// <summary>
    ///         Give the 5 seconds wait.After 5 seconds canvas is deactivated.
    /// </summary>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);                                     //return to the update function(from where routine is called) after waiting for 5 seconds.
        Canvas.gameObject.SetActive(false);         
    }

    /************* END OF CLASS ***********/
}