using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    private float speed = 5.0f;
    public Sprite AlienPhoto, AlienChangedPhoto;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
        StartCoroutine(ChangePhoto());
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "wallVert1") // move down and right
        {
            MoveDown();
            ChangeDirection(1);
        }
        if (collision.gameObject.name == "wallVert2") // move down and left
        {
            MoveDown();
            ChangeDirection(-1);
        }
        if(collision.gameObject.name == "spaceship" || collision.gameObject.name == "wallHor2")
        {
            collision.gameObject.GetComponent<SpaceShip>().life = 0;
        }
    }

    void ChangeDirection(int direction)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
    }
    void MoveDown()
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= 0.5f;
        this.transform.position = newPosition;
    }
    IEnumerator ChangePhoto()
    {
        while (true)
        {
            if (this.GetComponent<SpriteRenderer>().sprite == AlienPhoto)
            {
                this.GetComponent<SpriteRenderer>().sprite = AlienChangedPhoto;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = AlienPhoto;
            }

            yield return new WaitForSeconds(0.7f);
        }
    }
}
