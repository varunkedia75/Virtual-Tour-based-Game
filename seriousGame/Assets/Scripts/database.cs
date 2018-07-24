///<header>
///Module:            database
///Date of Creation : 13-04-18
///Author:			  Mukul Verma
///Modification history: 
///     13-04-18  :  Created module and functionality to show database interactions with the other modules.
///Synopsis:
///        This module contains the list of destination locations,checkpoints locations and start point locations
///Global Variable:
///        public static float timeLeft
///        public static float[,] endLocations
///        public static float[,] checkPoints
///        public static float[,] randomStartPos
///Functions:
///        void start()
///</header>

//imports required from the UnityEngine module
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class database : MonoBehaviour {

    //declaration of global variables.
    public static float timeLeft = 0;                                                                      //variable to store the time left in the game.                                          
    public static float[,] endLocations = new float[3, 3] { { -21.8f, 1.73f, -21.28f },                    //list of locations of destinations.
                                                            { 33.5f, 31.44f, -35.8f },      
                                                            { 9.74f, 24.12f, 15.11f } };
    public static string[] locationName = new string[3] { "Ground Floor Location",                               //list of names of locations of destinations.
                                                          "CSE 2nd year Lab",   
                                                          "Inkulu  Sir Room" };
    public static float[,] checkPoints = new float[3, 3] { { 31.79f, 1.5900f, 38.5f },                     //list of checkpoints.
                                                           { -21.8f, 1.73f, -21.28f }, 
                                                           { 35.04f, 18.65f, 42f } };
    public static float[,] randomStartPos = new float[3, 3] { { 31.79f, 3.91f, 38.5f },                    //list of starting locations of the game.
                                                              { 31.79f, 3.91f, 80.39f },
                                                              { 35.04f, 18.65f, 42f } };

    public static float[,] roomsLocation = new float[6, 3] { { 34.56f , 16.18f , -46.01f },  { 31.79f,3.91f,  38.5f},
                                                             { 35.66f , 1.77f , -45.95f }, { 33.5f, 31.44f, -35.8f },
                                                             { 6.28f , 20.97f,13.48f }, { 9.74f, 24.12f, 15.11f } };
    public static string[] roomsLocationName = new string[6] { "CSE Library" , "Ground Floor Location",
                                                                  "Seminar Room", "CSE 2nd year Lab",
                                                                  "Santosh Sir Room" ,  "Inkulu  Sir Room"};

    /// <summary>
    ///         Save the scene each time a new scene opens up ,in the database.
    /// </summary>
    void Start () {
        PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
	}

    /************* END OF CLASS ***********/
}
