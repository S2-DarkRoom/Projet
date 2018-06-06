using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Minuteur_multi : NetworkBehaviour
{
    [SyncVar] public float gameTime = 3600.0f; //The length of a game, in seconds.
    [SyncVar] public float timer; //How long the game has been running. -1=waiting for players, -2=game is done
    [SyncVar] public int minPlayers = 2; //Number of players required for the game to start
    [SyncVar] public bool masterTimer = false; //Is this the master timer?
                                               //public ServerTimer timerObj;

    Minuteur_multi serverTimer;

    void Start()
    {
        if (isServer)
        { // For the host to do: use the timer and control the time.
            if (isLocalPlayer)
            {
                serverTimer = this;
                masterTimer = true;
            }
        }
        else if (isLocalPlayer)
        { //For all the boring old clients to do: get the host's timer.
            Minuteur_multi[] timers = FindObjectsOfType<Minuteur_multi>();
            for (int i = 0; i < timers.Length; i++)
            {
                if (timers[i].masterTimer)
                {
                    serverTimer = timers[i];
                }
            }
        }
    }
    void Update()
    {
        if (masterTimer)
        { //Only the MASTER timer controls the time
            if (timer >= gameTime)
            {
                timer = -2;
            }
            else if (timer == -1)
            {
                if (NetworkServer.connections.Count >= minPlayers)
                {
                    timer = 0;
                }
            }
            else if (timer == -2)
            {
                //Game done.
                SceneManager.LoadScene("Menu");
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        if (isLocalPlayer)
        { //EVERYBODY updates their own time accordingly.
            if (serverTimer)
            {
                gameTime = serverTimer.gameTime;
                timer = serverTimer.timer;
                minPlayers = serverTimer.minPlayers;
            }
            else
            { //Maybe we don't have it yet?
                Minuteur_multi[] timers = FindObjectsOfType<Minuteur_multi>();
                for (int i = 0; i < timers.Length; i++)
                {
                    if (timers[i].masterTimer)
                    {
                        serverTimer = timers[i];
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 75, 20), "0 : " + ((gameTime / 60) % 60 - 1).ToString("0") + " : " + (gameTime % 60).ToString("0"));
    }
}
