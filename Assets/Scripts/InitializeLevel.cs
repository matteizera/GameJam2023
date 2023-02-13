using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject[] playerPrefab;

    private void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            Debug.Log("Posicao: " + i + " de " + playerConfigs.Length);
            var player = Instantiate(playerPrefab[playerConfigs[i].PlayerPrefab], playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<MovementPlayer>().InitializePlayer(playerConfigs[i]);
        } 
    }
}
