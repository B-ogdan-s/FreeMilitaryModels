using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompassSmollPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPrefab;
    [SerializeField] private Image _imagePrefab;

    [SerializeField] private RectTransform _rectTransform;

    [SerializeField, Min(0)] private int _addCount = 3;
    [SerializeField] private int _addRotate;

    private float _long;
    private float _rotateDelta;


    private void Awake()
    {
        for(int i = 0; i < 36; i++)
        {
            TextMeshProUGUI _text = Instantiate(_textPrefab, _rectTransform);
            _text.text = (i * 10).ToString();
            Instantiate(_imagePrefab, _rectTransform);
        }

        _long = (_textPrefab.rectTransform.sizeDelta.x + _imagePrefab.rectTransform.sizeDelta.x) * 36;

        _rotateDelta = _long / 360f;

        Debug.Log(_rotateDelta);
    }

    private void Start()
    {
        for (int i = 0; i < _addCount; i++)
        {
            TextMeshProUGUI _text = Instantiate(_textPrefab, _rectTransform);
            _text.text = (i * 10).ToString();
            Instantiate(_imagePrefab, _rectTransform);
        }
    }

    public void UpdatePosition(float position)
    {
        _rectTransform.localPosition = new Vector2(-(position + _addRotate) * _rotateDelta, _rectTransform.localPosition.y);

        //_rectTransform.localPosition += 
    }

}
