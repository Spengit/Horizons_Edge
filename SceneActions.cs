using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActions : MonoBehaviour
{
    public static bool gameEnd;
    public GameObject game_over_UI;

     void Start()
    {
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
            return;
        if(PlayerStatus.player_lives <= 0 )
        {
            gameOver();
        }
    }

    void gameOver()
    {
        gameEnd = true;

        game_over_UI.SetActive(true);
        Debug.Log("You died");
    }
}
