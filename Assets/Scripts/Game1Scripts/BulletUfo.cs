using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUfo : MonoBehaviour
{
    private float speed = 5.0f;

    
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        
        SoundManager.mySoundManager.PlayOneShot(SoundManager.mySoundManager.alienBullet);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == "Asteroid")
        {
            collision.GetComponent<Asteroid>().life--;
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player")
        {
            collision.GetComponent<SpaceShip>().life--;

            if (collision.GetComponent<SpaceShip>().life > 0)
            {
                SoundManager.mySoundManager.PlayOneShot(SoundManager.mySoundManager.spaceshipHit);
            }
            else
            {
                SoundManager.mySoundManager.PlayOneShot(SoundManager.mySoundManager.spaceshipExplosion);
            }

            Destroy(collision.GetComponent<SpaceShip>().listHearts[collision.GetComponent<SpaceShip>().life]);
            Destroy(this.gameObject);
        }
    }

}
