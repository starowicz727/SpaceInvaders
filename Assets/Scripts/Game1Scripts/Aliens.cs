using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    
    public List<GameObject> aliensList;
    public GameObject bulletUfo;
    float nextShotTime = -1;

    void Update()
    {
        CheckList();
        if (aliensList.Count > 0) { StartCoroutine(Shoot()); }
    }

    void CheckList()
    {
        for(int i=0; i<aliensList.Count; i++)
        {
            if (aliensList[i] == null)
            {
                aliensList.Remove(aliensList[i]);
            }
        }
    }
    GameObject RandomUfo()
    {
        int randInt = Random.Range(0, aliensList.Count);
        return aliensList[randInt];
    }

    public IEnumerator Shoot()
    {
        if(Time.time >= nextShotTime-2)
        {
            Instantiate(bulletUfo, RandomUfo().transform.position, Quaternion.identity);

            nextShotTime = Time.time + Random.Range(1f, 3f);
        }
        yield return new WaitForSeconds(1);
    }
}
