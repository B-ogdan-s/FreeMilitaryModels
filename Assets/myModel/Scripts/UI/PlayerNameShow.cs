using UnityEngine;
using TMPro;

public class PlayerNameShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    public void UpdatePlayerName()
    {
        _textMeshPro.text = PlayerPrefs.GetString("previousUsername");


    }
}
