//using System.Reflection.Metadata;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Multi : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;

    private void Awake(){
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start(){
        usernameMenu.SetActive(true); 
    }

    private void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        UnityEngine.Debug.Log("Connected");
    }

    public void ChangeUserNameInput(){
        if (UsernameInput.text.Length >= 3){
            StartButton.SetActive(true);
        }
        else{
            StartButton.SetActive(false);
        }
    }

    public void SetUserName(){
        usernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }
}
