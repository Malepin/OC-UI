using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

namespace Mirror.Examples.Chat
{
    [AddComponentMenu("")]
    public class ChatNetworkManager : NetworkManager
    {
        public Toggle[] OnlineIndicators;     

        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // remove player name from the HashSet
            if (conn.authenticationData != null)
                Player.playerNames.Remove((string)conn.authenticationData);


            // remove connection from Dictionary of conn > names
            ChatUI.connNames.Remove(conn);

            string newPlayer = (string)conn.authenticationData;
            newPlayer = newPlayer.Replace("OC", "");

            int playerIndex = -1;
            int.TryParse(newPlayer, out playerIndex);

            if (playerIndex > 0)
            {
                OnlineIndicators[playerIndex - 1].isOn = false;
                Debug.Log("A Player Has Left The Game");
            }

            base.OnServerDisconnect(conn);
        }

        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
            LoginUI.instance.gameObject.SetActive(true);
            LoginUI.instance.usernameInput.text = "";
            LoginUI.instance.usernameInput.ActivateInputField();
        }

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            base.OnServerConnect(conn);

            ChatUI.localPlayerName = (string)conn.authenticationData;
            ChatUI.connNames.Add(conn, (string)conn.authenticationData);

            string newPlayer = (string)conn.authenticationData;
            newPlayer = newPlayer.Replace("OC", "");

            int playerIndex = -1;
            int.TryParse(newPlayer, out playerIndex);

            if (playerIndex > 0)
            {
                OnlineIndicators[playerIndex - 1].isOn = true;
                Debug.Log("A Player Has Joined The Game");
            }          
          
        }


    }
}
