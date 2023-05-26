using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    //Variables for enemies left, total enemies, test display, win canvas, lose canvas
    public int enemiesLeft;
    public int enemiesTotal;
    public TMP_Text enemiesText;
    public Canvas winCanvas, loseCanvas;
    GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        //Find all enemies in the scene and assign the "total" count
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesTotal = enemies.Length;

        //Assign the text the value of remaining and total enemies
        enemiesText.text = enemiesTotal + "/" + enemiesTotal + " enemies down ";

        //Turn off win and lose canvas
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Find all enemies in the scene and assign the "remaining" count
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        enemiesText.text = enemiesLeft + "/" + enemiesTotal + " enemies down ";

        //Check if there are any enemies left, if not player wins, turn on the victory canvas3
        if(enemiesLeft == 0)
        {
            //Turn on the Canvas GameObject
            winCanvas.gameObject.SetActive(true);
            //Unlocks the cursor
            Cursor.lockState = CursorLockMode.None;

        }


    }
    public void PlayerDies()
    {
        loseCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }


}
