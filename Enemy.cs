
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float nme_speed = 5f;
    private Transform target;
    private int wave_index = 0;
    public int health = 100;
    public int value = 25;
    void Start()
    {
        target = waypoint.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * nme_speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {

            moveFoward();
        }
    }

   public void takeDamage(int damage)
    {
        health =  health - damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStatus.player_money += value;
        Destroy(gameObject);
    }

    void moveFoward()
    {
        if(wave_index >= waypoint.waypoints.Length - 1)
        {
            hitEnd();
            return;
        }
        wave_index++;
        target = waypoint.waypoints[wave_index];
    }

    void hitEnd(){
        PlayerStatus.player_lives--;
        Destroy(gameObject);
    }
}
