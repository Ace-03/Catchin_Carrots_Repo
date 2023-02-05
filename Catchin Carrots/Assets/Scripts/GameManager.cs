using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabLocation;
    public string FarmerPrefabLocation;
    public PlayerController[] players;
    public Transform[] CarrotSpawnPoints;
    public Transform[] FarmerSpawnPoints;
    public Transform jail;
    public int alivePlayers;
    public int CarrotsCaught;
    private int playersInGame;

    public float postGameTime;

    public List<string> alivePlayersList;
 
    //instance
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        alivePlayers = players.Length;

        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
        
    }

    [PunRPC]
    public void ImInGame()
    {
        Debug.Log("Im in game running." + PhotonNetwork.IsMasterClient);
        playersInGame++;

        if (PhotonNetwork.IsMasterClient && playersInGame == PhotonNetwork.PlayerList.Length)
        {
            photonView.RPC("FarmerSpawn", RpcTarget.MasterClient);
            photonView.RPC("SpawnPlayer", RpcTarget.Others);

        }
    }

    [PunRPC]
    public void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, CarrotSpawnPoints[Random.Range(0, CarrotSpawnPoints.Length)].position, Quaternion.identity);

        playerObj.GetComponent<PlayerController>().IsFarmer = false;
        //initalize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }


    [PunRPC]
    public void FarmerSpawn()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(FarmerPrefabLocation, FarmerSpawnPoints[Random.Range(0, CarrotSpawnPoints.Length)].position, Quaternion.identity);

        playerObj.GetComponent<PlayerController>().IsFarmer = true;

        //initalize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

    [PunRPC]
    public void CarrotJail(PlayerController carrot)
    {
        carrot.transform.position = jail.position;
    }

    public PlayerController GetPlayer(int playerId)
    {
        foreach(PlayerController player in players)
        {
            if (player != null && player.id == playerId)
                return player;
        }
        return null;
    }

    public PlayerController GetPlayer(GameObject playerObj)
    {
        foreach(PlayerController player in players)
        {
            if (player != null && player.gameObject == playerObj)
                return player;
        }
        return null;
    }

    public void CheckWinCondition()
    {
        if(CarrotsCaught == PhotonNetwork.PlayerList.Length -1)
            photonView.RPC("FarmerWins", RpcTarget.All);
    }

    [PunRPC]
    public void CarrotsWins()
    {
        SceneManager.LoadScene("CarrotEnd");
    }

    [PunRPC]
    public void FarmerWins()
    {
        SceneManager.LoadScene("FarmerEnd");

    }

    void GoBackToMenu()
    {
        NetworkManager.instance.ChangeScene("Menu Scene");
    } 

}
