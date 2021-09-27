using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawn : MonoBehaviour
{
    public Transform nme, spawnPoint;

    public float wave_timer = 15f;

    private float countdown = 3f;

    private int wave_num = 0;

    public Text waveText;

     void Update()
    {
        if (countdown <= 0) {
           StartCoroutine(spawning());
            countdown = wave_timer;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawning()
    {
        wave_num++;
        PlayerStatus.rounds_survived = wave_num;
        for (int i = 0; i < wave_num + 3; i++)
        {
            nmeSpawn();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void nmeSpawn()
    {
        Instantiate(nme, spawnPoint.position, spawnPoint.rotation);
    }


}
