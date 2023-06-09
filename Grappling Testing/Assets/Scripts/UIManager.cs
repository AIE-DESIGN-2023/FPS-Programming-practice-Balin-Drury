using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public int collectablesTotal;
    public int collectablesLeft;
    public Canvas winCanvas;
    public GameObject[] collectables;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //Find all enemies in the scene and assign the "total" count
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        collectablesTotal = collectables.Length;
        collectablesLeft = 14;


        //Turn off win and lose canvas
        winCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

        if(collectablesLeft == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winCanvas.gameObject.SetActive(true);
            PlayerMovement pm = FindObjectOfType<PlayerMovement>();
            if (pm != null)
            {
                pm.gameObject.SetActive(false);
            }
        }
        //collectablesLeft = collectables.Length;


    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Collected items: " + score;
        collectablesLeft--;
    }
    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }


}
