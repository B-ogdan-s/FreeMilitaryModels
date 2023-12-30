using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Compas : MonoBehaviour
{
    private Dictionary<int, string> _compasValue = new Dictionary<int, string>()
    {
        {0, "N"},
        {45, "NE" },
        {90, "E" },
        {135, "SE" },
        {180, "S" },
        {225,  "SW"},
        {270, "W" },
        {315, "NW" },
        {360, "N" }
    };

    private const float _rotateDelta = 22.5f;

    private const int _delta = 20;

    [SerializeField] private Transform _transform;
    [SerializeField] private TextMeshProUGUI _midleText;
    [SerializeField] private List<TextMeshProUGUI> _letText;
    [SerializeField] private List<TextMeshProUGUI> _rightText;

    [SerializeField] private TextMeshProUGUI _letterText;


    private void Update()
    {
        UpdateCompas();
    }

    private void UpdateCompas()
    {
        int r = (int)_transform.eulerAngles.y;

        _midleText.text = (r - (r % 10)).ToString();

        foreach (var c in _compasValue)
        {
            if (r > c.Key - _rotateDelta && r < c.Key + _rotateDelta)
            {
                _letterText.text = c.Value.ToString();
                break;
            }
        }


        for(int i = 1; i <= _letText.Count; i++)
        {
            int v = r - i * _delta;

            if (v < 0)
                v = 360 + v;

            _letText[i-1].text = (v - (v%10)).ToString();
        }

        for (int i = 1; i <= _rightText.Count; i++)
        {
            int v = r + i * _delta;

            if (v > 360)
                v = v - 360;

            _rightText[i-1].text =  (v - (v%10)).ToString();
        }
    }
}
