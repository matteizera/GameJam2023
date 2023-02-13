using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigurations;

    [SerializeField]
    private int MaxPlayer = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Singleton - Tentando iniciar outro singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigurations = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayerColer(int index, int prefab)
    {
        playerConfigurations[index].PlayerPrefab = prefab;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigurations[index].IsReady = true;
        if (playerConfigurations.Count == MaxPlayer && playerConfigurations.All(p => p.IsReady))
        {
            SceneManager.LoadScene("GAMEPLAY");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Jogador conectado" + pi.playerIndex);
        if (!playerConfigurations.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigurations.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigurations;
    }

}
