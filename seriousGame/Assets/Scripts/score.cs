///<header>
///Module:            score
///Date of Creation : 16-04-18
///Author:			  Mukul Verma
///Modification history: 
///     16-04-18  :  Created module and functionality to show the socre of the player at the end of the game.
///Synopsis:
///        This module calculates the score of the player and shows it at the end of the game.
///Global Variable:
///        public static float playerScore;
///        public Text scoreValue;
///Functions:
///        void Start ()
///        void Update()
///</header>

//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    //Declaration of the Global Vaiables
    public static float playerScore;
    public Text scoreValue;                                                         //Unity UI 2D text to show score on the screen.

    /// <summary>
    ///          Load the instance for the first time when screen loads.
    /// </summary>
    void Start () {
        playerScore = database.timeLeft;               
	}

	void Update () {


        //Check if user reached to the destination or not.
        if (playerScore > 0)
        {
            scoreValue.text = "Score : " + playerScore.ToString();                   //show the score on the screen
        }
        else
        {
            scoreValue.text = "Score : 0 ";                                         
        }
	}

    /************* END OF CLASS ***********/
}
