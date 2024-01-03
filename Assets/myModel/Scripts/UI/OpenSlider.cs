using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using MarsFPSKit.Weapons;


public class OpenSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isEnable = false;
    private bool _isClick = false;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;

        _slider.onValueChanged.AddListener((float value) =>
        { 
            _text.text = value.ToString("F1");
        });
    }

    private void OnEnable()
    {
        _text.text = _slider.value.ToString("F1");
    }

    public void OnClick()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isEnable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isEnable = false;

        if(!_isClick )
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
