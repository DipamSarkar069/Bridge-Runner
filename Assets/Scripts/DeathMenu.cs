using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public Text scoreText;
    
    public Image backgroundImg;
    private bool isShown = false;
    private float transition=0.0f;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false); //automatically turn off the menu in start  
    }

    // Update is called once per frame
    void Update()
    {
      if(!isShown)
      {
        return;
      }
      transition+=Time.deltaTime;
      backgroundImg.color=Color.Lerp(new Color(0,0,0,0),Color.yellow,transition); //animate the background colour in game over scene
        
    }

    //Activates the End Menu(Death Menu) when the player collides with something
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown=true;
    }

    //restarts the game when the player clicks restart button
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    //Takes the player back toMain Menu when the player clicks Back to Main Menu button
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
