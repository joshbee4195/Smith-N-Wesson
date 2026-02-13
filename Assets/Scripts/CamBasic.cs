using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamBasic : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    public TextMeshProUGUI scoreText;

    public GameObject endPopup;
    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        scoreText.SetText(gen.points.ToString() + " points");

       


        if (gen.gameOver)
        {
            endPopup.SetActive(true);
            endText.SetText("Score: " + gen.points.ToString());
        }
    }

    public void endClick()
    {

        gen.points = 0;
        gen.gameOver = false;
        Time.timeScale = 1;
        //reload scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

       
    }
}
