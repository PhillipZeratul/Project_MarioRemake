﻿using UnityEngine;
using Zenject;


public class LevelManager : MonoBehaviour
{
    public Transform playerSpawnPoint;

    [Inject(Id = Constants.InjectIDs.Player)]
    private GameObject player;


    private void Start()
    {
        player.transform.position = playerSpawnPoint.position;
    }
}
