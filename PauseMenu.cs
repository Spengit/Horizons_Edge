using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    int menu_index = 0;
    public GameObject pause_UI;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            paused();
        }
    }
    public void tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
        SceneManager.LoadScene(2);
    }

    public void menu ()
    {
        SceneManager.LoadScene(0);
    }

    void paused()
    {
        pause_UI.SetActive(!pause_UI.activeSelf);

        if(pause_UI.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
