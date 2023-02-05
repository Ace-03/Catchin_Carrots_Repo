using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabLocation;
    public string FarmerPrefabLocation;
    public PlayerController[] players;
    public Transform[] CarrotSpawnPoints;
    public Transform[] FarmerSpawnPoints;
    public int alivePlayers;

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

        //initalize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }


    [PunRPC]
    public void FarmerSpawn()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(FarmerPrefabLocation, FarmerSpawnPoints[Random.Range(0, CarrotSpawnPoints.Length)].position, Quaternion.identity);

        //initalize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
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

        if (alivePlayers == 1)
        {
            int killAmount = 0;
            string MostKillPlayerName = "";


            photonView.RPC("WinGame", RpcTarget.All, MostKillPlayerName, killAmount);
        }
    }

    [PunRPC]
    void WinGame(string winningPlayer, int killAmount)
    {
        // set the UI win text
        //GameUI.instance.SetWinText(winningPlayer,killAmount);

        Invoke("GoBackToMenu", postGameTime);
    }

    void GoBackToMenu()
    {
        NetworkManager.instance.ChangeScene("Menu Scene");
    }

    

}
