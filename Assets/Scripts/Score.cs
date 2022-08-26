using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNExtLevel = 10;

    private bool isDead = false;

    public Text scoreText;
    public Text scoreText_1;
    private int coinNumber;
    public AudioSource coinCollect;
    public DeathMenu DeathMenu;

    void Start()
    {
        coinNumber = 0;
        scoreText.text = "Coins : 0 " + coinNumber;
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead)
        {
            return;
        }
        //Calls the level up fuction which speeds up the player whenever the score is greater than scoreToNExtLevel which is 10
        if(score > scoreToNExtLevel)
        LevelUp();

        //prints score on the Screen and updates with every difficulty level
        score += Time.deltaTime*difficultyLevel;
        scoreText.text = ((int)score).ToString(); 
    }

    //increases the difficulty level of the game by increasing the speed of the player 
    void LevelUp()
    {
        
        if(difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNExtLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);//calls the SetSpeed function from the 'PlaterMotor' Script

        //Debug.Log(difficultyLevel);
    }

    //Updates and shows the Highscore at the main menu
    public void OnDeath()
    {
        isDead = true;

        if(PlayerPrefs.GetFloat("HIGHSCORE")<score)
        PlayerPrefs.SetFloat("HIGHSCORE", score);
        
        DeathMenu.ToggleEndMenu(score);
    }

    private void OnTriggerEnter(Collider Coins)
    {
        coinNumber++;
        coinCollect.Play();
        scoreText_1.text = "Coins : " + coinNumber;
        Destroy(Coins.gameObject);
    }
}
