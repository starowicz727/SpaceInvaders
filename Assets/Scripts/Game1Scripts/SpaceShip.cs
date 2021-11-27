using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.ParticleSystemJobs;

public class SpaceShip : MonoBehaviour
{
    private float speed = 8.0f;
    public GameObject bullet;
    public int life = 3;
    public List<GameObject> listHearts = new List<GameObject>();
    public Text pointsTxt;

    public Text endText;
    public InputField endInputField;
    public GameObject aliensInGame;

    public GameObject fire;
   

    private void Start()
    {
        SoundManager.mySoundManager.PlayInLoop(SoundManager.mySoundManager.gameSong);
        bullet.gameObject.SetActive(true);
    }

    void Update()
    {
        Time.timeScale = 1;
        //"Horizontal" = left/right/a/d , set in ProjectSettings 
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed;
        fire.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed;

        //shooting
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        ShowPoints();

        if (life == 0 || GameState.points == GameState.maxPoints)
        {
            aliensInGame.SetActive(false);
            this.GetComponent<SpriteRenderer>().enabled = false;
            fire.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent("Halo").GetType().GetProperty("enabled").SetValue(this.GetComponent("Halo"), false);
            bullet.gameObject.SetActive(false);

            GameState.EndingGame(endText, endInputField);
           
        }

        if (Input.GetKeyDown(KeyCode.Escape))     
        {
            GameState.points = 0;
            SceneManager.LoadSceneAsync(0);
        }

    }
    public void ShowPoints()
    {
        pointsTxt.text = GameState.points.ToString();
    }

   

}


