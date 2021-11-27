using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player : IComparable<Player>
{
    public string playerName;
    public int score;

    public Player() { }
    public Player(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }

    public int CompareTo(Player other)
    {
       if(this.score > other.score) { return -1; }
       else if(this.score < other.score) { return 1; }
       return 0;
    }
}
