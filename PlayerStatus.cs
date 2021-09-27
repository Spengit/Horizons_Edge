using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int player_money, player_lives;
    public int start_money = 500, start_lives = 100;
    public static int rounds_survived;

    void Start()
    {
        player_money = start_money;

        player_lives = start_lives;
        rounds_survived = 0;
    }
}
