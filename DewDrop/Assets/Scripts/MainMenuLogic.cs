﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class MainMenuLogic : MonoBehaviour
{
    private void Start()
    {
        EnterOnlineTestGame();
    }

    public void EnterOnlineTestGame()
    {
        LobbyManager.gameType = GameType.OnlineTestGame;
        LobbyManager.properlyConfiguredGame = true;

        SceneManager.LoadScene("Lobby");
    }


}
