using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currHealth;
    public HealthBar hb;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        hb.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //taking damage (add later)
}
