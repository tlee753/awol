using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static bool isPaused;

    public GameObject rogue;
    public GameObject player;
    public GameObject map;
    public GameObject map1;
    public GameObject player1;
    public GameObject player2;
    public Text roundText;
    public Text rogueText;
    public Text scoreText;

    public int roundNumber;
    public int roundRogues; // rogues per round
    public static int currentRogues; // current amount
    public int totalRogues; // total spawned per round
    public int maxRogues; // total allowed spawned

    public Vector3[] spawnLocations;

    private int counter;
    private int player1OldScore;

    void Start()
    {
        isPaused = false;

        totalRogues = 0;
        roundNumber = 1;
        currentRogues = 0;
        maxRogues = 24;
        roundRogues = 2 * roundNumber;

        counter = 0;
        player1OldScore = 0;

        spawnLocations = new Vector3[4] {new Vector3(-95, 50, 0), new Vector3(145, 0, 0), new Vector3(50, 95, 0), new Vector3(100, -95, 0)};

        map = Resources.Load("BoxMap") as GameObject;
        player = Resources.Load("Player") as GameObject;
        rogue = Resources.Load("Rogue") as GameObject;

        map1 = Instantiate(map, new Vector3(0, 0, 0), Quaternion.identity);
        player1 = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        //player2 = Instantiate(player, new Vector3(30, 0, 0), Quaternion.identity);

        roundText = GameObject.Find("RoundText").GetComponent<Text>();
        rogueText = GameObject.Find("RogueText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        // spawn zombies based on equation and randomness
        if (currentRogues < maxRogues && totalRogues < roundRogues && counter > 100)
        {
            Instantiate(rogue, spawnLocations[Random.Range(0, 100) % spawnLocations.Length], Quaternion.identity);
            currentRogues++;
            totalRogues++;
            rogueText.text = currentRogues.ToString();

            counter = 0;
        }
        else if (totalRogues >= roundRogues && GameObject.FindGameObjectWithTag("Rogue") == null) {
            roundNumber++;
            roundRogues = 2 * roundNumber;
            totalRogues = 0;
            currentRogues = 0;
            rogueText.text = (roundRogues - totalRogues + currentRogues).ToString();
            roundText.text = roundNumber.ToString();
        }
        else
        {
            rogueText.text = (roundRogues - totalRogues + currentRogues).ToString();
        }

        if (PlayerController.score != player1OldScore)
        {
            player1OldScore = PlayerController.score;
            scoreText.text = player1OldScore.ToString();
            if (player1OldScore > 10000)
            {
                scoreText.text = "You Win!!!";
                pauseGame();
            }
        }

        counter++;
    }

    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        isPaused = !isPaused;
    }

}
