using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject[] rooms;

    public GameObject pause;
    public GameObject roomButs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //buttons

    public void minigame1click()
    {
        //S+W

        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == 0)
            {
                rooms[i].SetActive(true);
            }

            else
            {
                rooms[i].SetActive(false);
            }


        }

        pause.SetActive(true);
        roomButs.SetActive(false);
    }

    public void minigame2click()
    {
        //baguettes

        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == 1)
            {
                rooms[i].SetActive(true);
            }

            else
            {
                rooms[i].SetActive(false);
            }


        }

        pause.SetActive(true);
        roomButs.SetActive(false);
    }

    public void minigame3click()
    {
        //barbarian

        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == 2)
            {
                rooms[i].SetActive(true);
            }

            else
            {
                rooms[i].SetActive(false);
            }


        }

        pause.SetActive(true);
        roomButs.SetActive(false);
    }
}
