using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int life = 1;
    
    void Update()
    {
        if (life == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ufo")
        {
            Destroy(this.gameObject);
        }
    }

    
}
