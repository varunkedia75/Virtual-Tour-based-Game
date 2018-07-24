///<header>
///Module:            volumeController
///Date of Creation : 17-04-18
///Author:			  Mukul Verma
///Modification history: 
///     17-04-18  :  Created module and functionality to control the game sound level.
///Synopsis:
///        This module changes the sound level of the game.
///Global Variable:
///       public Slider slider;
///       public AudioSource source;
///       public int currentScene;
///Functions:
///       void Awake()
///       public void back()
///       public void volume()
///</header>


//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class volumeController : MonoBehaviour {

    //Declaration of Global variables
    public Slider slider;                                                                       //Unity UI slider to control the volume.
    public AudioSource source;                                                                  //Unity Audio Source
    public int currentScene;

    /// <summary>
    ///         Load the instance whenever the scene opens.
    /// </summary>
    void Awake()
    {

        source = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();         
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");

        //check if more than one audio source are active in the scene
        if(obj.Length > 1)
        { 
            Destroy(this.gameObject);                                                           //destroy the audio sources if more than one are found
        }
        DontDestroyOnLoad(obj[0]);                                                              //retain the same audio source around different scenes 
    }


    /// <summary>
    ///         Change the audio level.
    /// </summary>
    public void volume()
    {
        source.volume = slider.value;
    }


    /// <summary>
    ///         Go back to the scene from which control menu is opened after loading the game data(when game is paused) 
    ///         like time and player position back to the what it was when control menu was opened.
    /// </summary>
    public void back()
    {
        timer.timeLeft = PlayerPrefs.GetFloat("time");  
        restart.resume = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));                        //Get the last saved scene from control menu was opened.
        
    }
    /************* END OF CLASS ***********/
}
