using MarsFPSKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class RaundInfo : MonoBehaviour
{
    public static RaundInfo Instance;

    [SerializeField] private Kit_IngameMain _ingameMain;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _time;

    [SerializeField] private TextMeshProUGUI _roundText;
    [SerializeField] private TextMeshProUGUI _rightText;

    [SerializeField] private Image _prefab;
    [SerializeField] private Transform _leftParent;
    [SerializeField] private Transform _rightParent;

    [SerializeField] private Color _leftColor;
    [SerializeField] private Color _rightColor;

    [SerializeField, Min(0)] private float _alphaValue = 0.3f;
    [SerializeField, Min(0)] private int _count = 3;

    private List<Image> _leftPanel = new List<Image>();
    private List<Image> _rightPanel = new List<Image>();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        _leftPanel = SpawnPanel(_leftParent, _leftColor);
        _rightPanel = SpawnPanel(_rightParent, _rightColor);

        _canvas.enabled = false;
    }

    public void Open(Kit_IngameMain kit_IngameMain, string roundText)
    {
        _canvas.enabled = true;

        _roundText.text = roundText;

        StartCoroutine(Pause());

        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (!player.IsLocal)
            {
                _rightText.text = player.NickName;
            }
        }

        ExitGames.Client.Photon.Hashtable myTable = PhotonNetwork.LocalPlayer.CustomProperties;
        int kills = (int)myTable["kills"];
        int deaths = (int)myTable["deaths"];

        EnablePanel(_leftPanel, kills, _leftColor);
        EnablePanel(_rightPanel, deaths, _rightColor);

        if(kills == 3)
        {
            _roundText.text = "you win";
            _roundText.color = _leftColor;
            StartCoroutine(Disconect());
        }
        if (deaths == 3)
        {
            _roundText.text = "you lost";
            _roundText.color = _rightColor;
            StartCoroutine(Disconect());
        }
    }
    private IEnumerator Disconect()
    {
        yield return new WaitForSeconds(_time);
        _ingameMain.Disconnect();
    }


    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(_time);
        _canvas.enabled = false;
    }

    private List<Image> SpawnPanel(Transform parent, Color color)
    {
        List<Image> images = new List<Image>();

        for(int i = 0; i < _count; i++)
        {
            Image image = Instantiate(_prefab, parent);
            image.color = new Color( color.r, color.g, color.b, _alphaValue);
            images.Add(image);
        }

        return images;
    }

    private void EnablePanel(List<Image> images, int count, Color color)
    {
        for(int i = 0; i < count; i++) 
        {
            images[i].color = color;
        }
    }
}
