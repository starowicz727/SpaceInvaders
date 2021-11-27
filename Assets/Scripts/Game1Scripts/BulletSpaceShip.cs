using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpaceShip : MonoBehaviour
{
    private float speed = 8.0f;
    public GameObject explosion;
   
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        
        SoundManager.mySoundManager.PlayOneShot(SoundManager.mySoundManager.spaceshipBullet);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == "Ufo")
        {
            GameState.points += 27;   
            SoundManager.mySoundManager.PlayOneShot(SoundManager.mySoundManager.alienExplosion);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.tag == "BulletUfo")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Asteroid")
        {
            Destroy(this.gameObject);
        }
    }

}
