using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShow : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;

    [SerializeField] private Image _characterShow;

    public Action<ButtonShow> OnClick;

    private void Awake()
    {
        _button.onClick.AddListener(() => OnClick?.Invoke(this));
    }

    public void SetCharacter(Sprite character)
    {
        _characterShow.sprite = character;
    }

    public void Disable()
    {
        _image.enabled = false;
    }
    public void Enable()
    {

        _image.enabled = true;
    }
}
