using UnityEngine;
using System.Collections;

public class OnJoinedInstantiate : MonoBehaviour
{
    public Transform SpawnPosition;
    public float PositionOffset = 2.0f;
    public GameObject[] PrefabsToInstantiate;   // set in inspector
    private ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();
    private int _copiedPositionNumber;

    void Start()
    {

    }

    public void OnJoinedRoom()
    {
        PhotonNetwork.isMessageQueueRunning = true;
        _copiedPositionNumber = (int)PhotonNetwork.room.CustomProperties["PositionNumber"];
        _copiedPositionNumber++;

        roomHash.Add("PositionNumber", _copiedPositionNumber);
        PhotonNetwork.room.SetCustomProperties(roomHash);

        if (this.PrefabsToInstantiate != null)
        {
            foreach (GameObject o in this.PrefabsToInstantiate)
            {
                Debug.Log("Instantiating: " + o.name);

                Vector3 spawnPos = Vector3.up;
                if (this.SpawnPosition != null)
                {
                    spawnPos = this.SpawnPosition.position;
                }

                Vector3 random = Random.insideUnitSphere;
                random.y = 0;
                random = random.normalized;
                Vector3 itempos = spawnPos + this.PositionOffset * random;

                var i = (int)PhotonNetwork.room.CustomProperties["PositionNumber"];


                var obj = PhotonNetwork.Instantiate(o.name, itempos, Quaternion.identity, 0);
                obj.name = "sync" + i;
            }
        }
    }
}
