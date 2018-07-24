///<header>
///Module:            destination
///Date of Creation : 12-04-18
///Author:			  Mukul Verma
///Modification history: 
///     12-04-18  :  Created module and functionality to place the player at different locations in the game.
///Synopsis:
///        This module takes the list of starting positions from the database module  and place the player at one of the randomly chosen 
///        location in the game and also ersumes from the last location if player slects the resume option
///Global Variable:
///         public Transform player;
///         public Transform finalLocationIndicator;
///         public static int index;
///         public Text destinationName;
///         public static bool checkPreviousDestination
///Functions:
///        void start()
///        void Update()
///</header>

//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

    //Declaration of Global variables from Unity  studio
    public Transform player;

    //Declaration of private variabel for use in script
    public float xpos;
    public float ypos;
    public float zpos;
    private Vector3 randPos;
    private int index;


    /// <summary>
    ///         Load the instance when first frame loads;
    /// </summary>
    void Start () {
        //Check if the player restarted the game or selects a new game
        if (restart.resume == true)
        {
            //place the player at saved location in the database
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), PlayerPrefs.GetFloat("positionZ"));       
            Time.timeScale = 1;                                                                     
            timer.timeLeft = PlayerPrefs.GetFloat("time");                                      //set the time to saved time (when the player had stopped the game.)
            restart.resume = false;                                                     
        }
        else
        {
            timer.timeLeft = 60.0f;                                                             //start the new timer
            index = Random.Range(0, 3);                                                         //selects the new startinf location
            xpos = database.randomStartPos[index, 0];
            ypos = database.randomStartPos[index, 1];
            zpos = database.randomStartPos[index, 2];
            randPos.x = xpos;                                                                   
            randPos.y = ypos;
            randPos.z = zpos;
            transform.position = randPos;                                                       //place the  player at the random location.
        }  
    }
    /************* END OF CLASS ***********/

}
