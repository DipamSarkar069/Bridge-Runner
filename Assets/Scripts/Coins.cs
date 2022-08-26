using UnityEngine;
using UnityEngine.UIElements;

public class Coins : MonoBehaviour
{
    public TextElement scoreText_1;
    private int coinNumber;
    //public AudioSource coinCollect;
    // Start is called before the first frame update
    void Start()
    {
        coinNumber = 0;
        scoreText_1.text = "Coins : " + coinNumber;
    }

    private void OnTriggerEnter(Collider Coins)
    {
        coinNumber++;
        //coinCollect.Play();
        scoreText_1.text = "Coins : " + coinNumber;
        Destroy(Coins.gameObject);
    }
}

