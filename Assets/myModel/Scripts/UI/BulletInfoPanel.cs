using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletInfoPanel : MonoBehaviour
{
    public static BulletInfoPanel Instance;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private string _reloadText;
    [SerializeField] private string _noAmmoText;
    [SerializeField] private string _lowAmmoText;

    [SerializeField] private Color _reloadColor;
    [SerializeField] private Color _noAmmoColor;
    [SerializeField] private Color _lowAmmoColor;

    public bool _isReload = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Disable();
    }

    public void Enable()
    {
        _canvas.enabled = true;
    }
    public void Disable()
    {
        if (_isReload)
        {
            Reload();
            return;
        }

        _canvas.enabled = false;
    }

    public void Reload()
    {
        Enable();
        _text.text = _reloadText;
        _text.color = _reloadColor;
    }
    public void NoAmmo()
    {
        if (_isReload)
        {
            Reload();
            return;
        }

        Enable();
        _text.text = _noAmmoText;
        _text.color = _noAmmoColor;
    }
    public void LowAmmo()
    {
        if( _isReload )
        {
            Reload();
            return;
        }    

        Enable();
        _text.text = _lowAmmoText;
        _text.color = _lowAmmoColor;
    }

}
