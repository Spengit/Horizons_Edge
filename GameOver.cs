using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text rounds;

     void OnEnable()
    {
        rounds.text = "Rounds: " + PlayerStatus.rounds_survived.ToString();
    }

    public void menu ()
    {
        SceneManager.LoadScene(0);
    }

    public void retry()
    {
        SceneManager.LoadScene(2);
    }
}
