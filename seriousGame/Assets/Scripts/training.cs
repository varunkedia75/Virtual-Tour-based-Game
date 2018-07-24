///<header>
///Module:            training
///Date of Creation : 19-04-18
///Author:			  Mukul Verma
///Modification history: 
///     19-04-18  :  Created module and functionality to provide the player a tour of the game.
///Synopsis:
///        This module loads the tour of the cse department and show the labels infront of the rooms.
///Global Variable:
///         public Transform player;
///         public Transform finalLocationIndicator;
///         public TextMesh labelText;
///Functions:
///        void start()
///        void Update()
///</header>

//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training : MonoBehaviour {

    //Declaration of Global Variables for the Unity.
    public Transform player;
    public Transform roomNameLabel;
    public TextMesh labelText;

    //Declaration of private variables used in the script.
    private float xpos;
    private float ypos;
    private float zpos;

    
    /// <summary>
    ///         Load the instance when the first frame loads
    /// </summary>
    void Start () {
        roomNameLabel.gameObject.SetActive(false);                                                          //Deactivates the label for name of the rooms 
    }
	

    /// <summary>
    ///         Load the instance each time when the frame loads.
    /// </summary>
	void Update () {
        xpos = player.transform.position.x;                                                                 //get the 'x' coordinates of the player location
        ypos = player.transform.position.y;                                                                 //get the 'y' coordinates of the player location
        zpos = player.transform.position.z;                                                                 //get the 'z' coordinates of the player location


        for (int i = 0; i < 6; i++)
        {
            //Check of the player is in near some room or not .
            if ((xpos > (database.roomsLocation[i, 0] - 10)) && (xpos < (database.roomsLocation[i, 0] + 10)) && (ypos > (database.roomsLocation[i, 1] - 10)) && (ypos < (database.roomsLocation[i, 1] + 10)) && (zpos > (database.roomsLocation[i, 2] - 10)) && (zpos < (database.roomsLocation[i, 2] + 10)))
            {
                roomNameLabel.transform.position = new Vector3(database.roomsLocation[i, 0], database.roomsLocation[i, 1] + 3, database.roomsLocation[i, 2]);           //set the location of the label in front of the room
                roomNameLabel.gameObject.SetActive(true);                                                                                                               //show the label
                labelText.text = database.roomsLocationName[i];                                                                                                         //set the name of label to the name of the room
                StartCoroutine(Wait());
            }
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);                                     //return to the update function(from where routine is called) after waiting for 5 seconds.
        roomNameLabel.gameObject.SetActive(false);
    }


}
