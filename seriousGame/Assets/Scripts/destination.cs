///<header>
///Module:            destination
///Date of Creation : 15-04-18
///Author:			  Mukul Verma
///Modification history: 
///     15-04-18  :  Created module and functionality to end the game when player reaches at the destination.
///Synopsis:
///        This module takes the list of destinations from the database module and also shows a 3D text
///        in the screen to show the where the player has to go( i.e. destination ) to complete the game.
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
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class destination : MonoBehaviour
{
   
    //Declaration of Global Variables for the Unity.
    public Transform player;                                                
    public Transform finalLocationIndicator;                                            //3D text from unity to show the player where is the destination.
    public static int index;                                                            
    public Text destinationName;                                                        //Unity UI 2D text to show the destination name on the screen.
    public static bool checkPreviousDestination = false;                                //bool to show whether to set the previously loaded destination as in case of resume or find a new one as in case of new game.  

    //Declaration of private variables used in the script.
    private float xpos;
    private float ypos;
    private float zpos;                 
    private float endLocationX;                                                         //variable to store the 'x' coordinate of destination.
    private float endLocationY;                                                         //variable to store the 'y' coordinate of destination.
    private float endLocationZ;                                                         //variable to store the 'z' coordinate of destination.

 
    /// <summary>
    ///         Set the destination and show on the screen when the screen loads(i.e. first frame)
    /// </summary>
    void Start()
    {
        ///check if game is resumed or newly played.
        if (checkPreviousDestination == false)
        {
            index = Random.Range(0, 3);                                                 //find the new location randomly if newly played.
            finalLocationIndicator.transform.position = new Vector3(database.endLocations[index, 0], database.endLocations[index, 1], database.endLocations[index, 2]);         //set the location of 3D text indicator
        }
        else
        {
            index = PlayerPrefs.GetInt("destinationIndex");                             //load the previous llocation if resumed
            checkPreviousDestination = false;                                           
        }
        destinationName.text = "Destination : " + database.locationName[index];         //show the name of destination on the screen
    }


    /// <summary>
    ///         Update this instance,once a frame.
    /// </summary>
    void Update()
    {               
        xpos = player.transform.position.x;                                             //get the 'x' coordinate of  current position of player.
        ypos = player.transform.position.y;                                             //get the 'y' coordinate of  current position of player.
        zpos = player.transform.position.z;                                             //get the 'z' coordinate of  current position of player.
        endLocationX = database.endLocations[index, 0];                                 //get the 'x'  coordinate of destination.
        endLocationY = database.endLocations[index, 1];                                 //get the 'y'  coordinate of destination.
        endLocationZ = database.endLocations[index, 2];                                 //get the 'z'  coordinate of destination.


        //Check if player is reached in 5f radius of destination or not
        if ((xpos > (endLocationX - 5) && xpos < (endLocationX + 5)) && (ypos > (endLocationY - 5) && ypos < (endLocationY + 5)) && (zpos > (endLocationZ - 5) && zpos < (endLocationZ + 5)))
        {
            database.timeLeft = timer.timeLeft;                                         
            SceneManager.LoadScene(1);                                                  //end the game and load the end game scene(i.e. scene 1 in this game)
        }
    }

    /************* END OF CLASS ***********/
}