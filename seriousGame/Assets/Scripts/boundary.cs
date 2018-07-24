///<header>
///Module:            boundary
///Date of Creation : 18-04-18
///Author:			  Mukul Verma
///Modification history: 
///     18-04-18  :  Created module and functionality to restrict and alert the player.
///Synopsis:
///        This module alerts the player when he/she is going to crossing the boundary of the game.
///Global Variable:
///        public Transform player
///        public Transform errorLabel
///Functions:
///        void Update()
///        void Start()
///</header>


//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour {
    
    // Declaration of Global variables from Unity  studio
    public Transform player;
    public Transform errorLabel;

    //Declaration of private variabel for use in script
    private float xpos;
    private float ypos;
    private float zpos;
    
	/// <summary>
    ///     Load the instance when first frame loads
    /// </summary>
	void Start () {
        errorLabel.gameObject.SetActive(false);                                                 //Deactivate the error Label
	}

    /// <summary>
    /// /       Update is called once per frame
    /// </summary>
    void Update () {
        xpos = player.transform.position.x;                                                     //get the 'x' coordinate of  current position of player.
        ypos = player.transform.position.y;                                                     //get the 'y' coordinate of  current position of player.
        zpos = player.transform.position.z;                                                     //get the 'z' coordinate of  current position of player

        //Check if user is going near the boundary of the game oor not
        if (xpos > 200f || xpos < -200f || zpos > 200f || zpos < -200f)
        {
            errorLabel.gameObject.SetActive(true);                                              //show the error label
            errorLabel.transform.position = new Vector3(xpos + 5, ypos + 5, zpos + 5);
        }
        else
        {
            errorLabel.gameObject.SetActive(false);                                             
        }
	}
    /************* END OF CLASS ***********/
}

