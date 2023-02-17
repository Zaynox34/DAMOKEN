using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int healthPoint;

    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 100;
        
    }

    public void Hurt(int damage)
    {
        healthPoint -= damage;
    }
    public void Recovery(int health)
    {
        healthPoint += health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
