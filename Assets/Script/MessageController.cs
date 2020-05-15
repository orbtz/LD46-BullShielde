using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageController : MonoBehaviour
{

    public EndState State;

    public GameObject MENU;
    public GameObject GOOD;
    public GameObject BAD;

    public bool isPlaying = false;

    private void Start()
    {
        isPlaying = false;

        Time.timeScale = 0;
        MENU.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
        {
            MENU.SetActive(false);
            isPlaying = true;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (State.Die == true)
        {
            BAD.SetActive(true);
            
        }

        if (State.Ended == true)
        {
            GOOD.SetActive(true);
            
        }

    }

}
