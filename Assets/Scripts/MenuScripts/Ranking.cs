using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text[] names = new Text[10];
    public Text[] points = new Text[10];

    public void Update()
    {
        GameState.ReadData();

        for(int i=0; i<10; i++)
        {
            names[i].text = GameState.RankPlayers[i].playerName;
            points[i].text = GameState.RankPlayers[i].score.ToString();
        }
    }

}
