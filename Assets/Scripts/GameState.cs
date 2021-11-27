using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameState
{
    public static int points = 0;
    public static string userName = "";
    static string fileName = "..\\ourDatas.txt";
    public static List<Player> RankPlayers = new List<Player>();
    public static int maxPoints = 27*24; // we have currently 24 aliens in game

    public static bool soundEffectsOn = true;
    public static bool musicOn = true;

    
    public static void EndingGame(Text message, InputField userInput)
    {
        //SaveData();
        

        Player ourPlayer = new Player(userName, points);
        ReadData();
        Time.timeScale = 0;
        if(ourPlayer.score >= RankPlayers[RankPlayers.Count - 1].score  && ourPlayer.score!=0 )
        {
            
            userInput.gameObject.SetActive(true);
            message.gameObject.SetActive(true);

            message.text = (points == maxPoints) ? "YOU WIN! \n" : "NICE SCORE! \n";
            message.text += "ENTER YOUR NAME AND PRESS ENTER TO SUBMIT: ";

            if (Input.GetKeyDown("return"))
            {
                ourPlayer.playerName = userInput.text;
                RankPlayers.Add(ourPlayer);
                RankPlayers.Sort();
                RankPlayers.RemoveAt(RankPlayers.Count - 1);
                SaveData();
                points = 0;
                userName = "";
                Time.timeScale = 1;
                SceneManager.LoadSceneAsync(0);
            }
        }
        else
        {
            message.gameObject.SetActive(true);
           
            message.text = "YOU LOSE :( \n PRESS R TO RETURN TO MENU";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadSceneAsync(0);
            }
        }
        
    }

    

    public static void SaveData()
    {
        string path = fileName;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        ////first time 
        //for(int i=0; i<10; i++)
        //RankPlayers.Add(new Player());

        formatter.Serialize(stream, RankPlayers);
        stream.Close();
    }

    public static void ReadData()
    {
        string path = fileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RankPlayers = formatter.Deserialize(stream) as List<Player>;
            stream.Close();
        }
        else
        {
            Debug.LogError("File not found in" + path);
        }
       
    }



}
