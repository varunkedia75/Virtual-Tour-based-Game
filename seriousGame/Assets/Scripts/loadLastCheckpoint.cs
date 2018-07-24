///<header>
///Module:            loadCheckpoint
///Date of Creation : 08-04-18
///Author:			  Mukul Verma
///Modification history: 
///     08-04-18  :  Created module and functionality to load the game from the last checkpoint.
///Synopsis:
///        This module takes saved checkpoint location from the database and load the game again from that location.
///Global Variable:
///        public Transform player;
///Functions:
///        public void loadPreviousCheckpoint()
///</header>

//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadLastCheckpoint : MonoBehaviour {

    //Declaration of Global Variables
    public Transform player;

    //Declaration of private variables used in the script.
    private float playerPositionX;                                                      
    private float playerPositionY;
    private float playerPositionZ;

    /// <summary>
    ///         Set the location of the Player to last location of last checkpoint. 
    /// </summary>
    public void loadPreviousCheckpoint()
    {
        playerPositionX = PlayerPrefs.GetFloat("positionX");                                            //get the 'x' position of the saved last location of checkpoint.
        playerPositionY = PlayerPrefs.GetFloat("positionY");                                            //get the 'y' position of the saved last location of checkpoint.
        playerPositionZ = PlayerPrefs.GetFloat("positionZ");                                            //get the 'z' position of the saved last location of checkpoint.

        player.transform.position = new Vector3(playerPositionX, playerPositionY, playerPositionZ);     //set the position of the player to last checkpoint. 
        timer.timeLeft = PlayerPrefs.GetFloat("time");                                                  //set the time to the previously saved time. 
        restart.resume = true;;
        Time.timeScale = 1;                                                                             //Start the time of the game.
        SceneManager.LoadScene(0);                                                                      //start the game. 
    }

    /************* END OF CLASS ***********/
}
