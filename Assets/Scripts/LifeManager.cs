using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int healthPoint;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 100;
        dead = false;
    }

    public void Hurt(int damage)
    {
        if(!dead)
        {
            healthPoint -= damage;
        }
       
    }
    public void Recovery(int health)
    {
        healthPoint += health; 
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoint<=0)
        {
            dead=true;
        }
    }
}
