using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CangeDropdownt : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    [SerializeField] private TextMeshProUGUI _text;


    private void Awake()
    {
        _text.text = _dropdown.options[_dropdown.value].text.ToString();
    }

    public void LeftClick()
    {
        _dropdown.value--;

        _text.text = _dropdown.options[_dropdown.value].text.ToString();

    }
    public void RightClick() 
    {
        _dropdown.value++;

        _text.text = _dropdown.options[_dropdown.value].text.ToString();
    }
}
