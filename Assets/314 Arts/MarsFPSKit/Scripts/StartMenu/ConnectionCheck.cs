using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionCheck : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Update()
    {
        if(PhotonNetwork.IsConnected)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
