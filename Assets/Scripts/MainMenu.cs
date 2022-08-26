using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HIGHSCORE : "+ ((int)PlayerPrefs.GetFloat("HIGHSCORE")).ToString(); //Hsaws the Highscore at the Top
        
    }

    //The Game starts when the player clicks Play
    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
