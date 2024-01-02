using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MarsFPSKit
{
    namespace UI
    {
        [System.Serializable]
        public class OptionsCategory
        {
            /// <summary>
            /// Name of the category
            /// </summary>
            public string categoryName;

            /// <summary>
            /// Options for this category
            /// </summary>
            public Kit_OptionBase[] options;
        }

        /// <summary>
        /// This is the kit's new modular options menu!
        /// </summary>
        public class Kit_MenuOptions : MonoBehaviour
        {
            /// <summary>
            /// ID
            /// </summary>
            public int optionsScreenId = 9;

            /// <summary>
            /// Option categories
            /// </summary>
            public OptionsCategory[] categories;

            /// <summary>
            /// Where the categories go
            /// </summary>
            public RectTransform categoryGo;
            /// <summary>
            /// Prefab for the category selection
            /// </summary>
            public GameObject categoryPrefab;

            /// <summary>
            /// List Go
            /// </summary>
            public RectTransform optionsListGo;

            /// <summary>
            /// Slider prefab
            /// </summary>
            public GameObject optionSlider;
            /// <summary>
            /// Dropdown prefab
            /// </summary>
            public GameObject optionDropdown;
            /// <summary>
            /// Toggle prefab
            /// </summary>
            public GameObject optionToggle;

            /// <summary>
            /// Category ID
            /// </summary>
            public List<GameObject[]> optionsCategories = new List<GameObject[]>();

            /// <summary>
            /// Hover Info
            /// </summary>
            public TextMeshProUGUI hoverInfo;

            private void Start()
            {
                //Create Categories
                for (int i = 0; i < categories.Length; i++)
                {
                    int id = i;
                    GameObject go = Instantiate(categoryPrefab, categoryGo, false);
                    //Setup text
                    TextMeshProUGUI txt = go.GetComponent<TextMeshProUGUI>();
                    txt.text = categories[id].categoryName;
                    //Setup Call
                    //Button btn = go.GetComponentInChildren<Button>();
                    //btn.onClick.AddListener(delegate { SelectCategory(id); });

                    //Create array for storing
                    GameObject[] array = new GameObject[categories[i].options.Length];
                    optionsCategories.Add(array);

                    //Create Options
                    for (int o = 0; o < categories[i].options.Length; o++)
                    {
                        int od = o;
                        if (categories[i].options[o].GetOptionType() == OptionType.Dropdown)
                        {
                            GameObject option = Instantiate(optionDropdown, optionsListGo, false);

                            TextMeshProUGUI[] texts = option.GetComponentsInChildren<TextMeshProUGUI>();
                            texts[0].text = categories[i].options[o].GetDisplayName();
                            texts[1].text = categories[i].options[o].GetHoverText();
                            EventTrigger et = option.AddComponent<EventTrigger>();
                            EventTrigger.Entry hover = new EventTrigger.Entry();
                            hover.eventID = EventTriggerType.PointerEnter;
                            hover.callback.AddListener(delegate { Hover(id, od); });
                            et.triggers.Add(hover);
                            TMP_Dropdown dropdown = option.GetComponentInChildren<TMP_Dropdown>();
                            categories[id].options[od].OnDropdownStart(texts[0], dropdown);
                            dropdown.onValueChanged.AddListener(delegate { categories[id].options[od].OnDropdowChange(texts[0], dropdown.value); });

                            //Add
                            optionsCategories[id][od] = option;
                            //Hide
                        }
                        else if (categories[i].options[o].GetOptionType() == OptionType.Slider)
                        {
                            GameObject option = Instantiate(optionSlider, optionsListGo, false);

                            TextMeshProUGUI[] texts = option.GetComponentsInChildren<TextMeshProUGUI>();
                            texts[0].text = categories[i].options[o].GetDisplayName();
                            texts[1].text = categories[i].options[o].GetHoverText();
                            EventTrigger et = option.AddComponent<EventTrigger>();
                            EventTrigger.Entry hover = new EventTrigger.Entry();
                            hover.eventID = EventTriggerType.PointerEnter;
                            hover.callback.AddListener(delegate { Hover(id, od); });
                            et.triggers.Add(hover);
                            Slider slider = option.GetComponentInChildren<Slider>();
                            categories[id].options[od].OnSliderStart(texts[0], slider);
                            slider.onValueChanged.AddListener(delegate { categories[id].options[od].OnSliderChange(texts[0],  slider.value); });

                            //Add
                            optionsCategories[id][od] = option;
                            //Hide
                        }
                        else if (categories[i].options[o].GetOptionType() == OptionType.Toggle)
                        {
                            GameObject option = Instantiate(optionToggle, optionsListGo, false);

                            TextMeshProUGUI[] texts = option.GetComponentsInChildren<TextMeshProUGUI>();
                            texts[0].text = categories[i].options[o].GetDisplayName();
                            texts[1].text = categories[i].options[o].GetHoverText();
                            EventTrigger et = option.AddComponent<EventTrigger>();
                            EventTrigger.Entry hover = new EventTrigger.Entry();
                            hover.eventID = EventTriggerType.PointerEnter;
                            hover.callback.AddListener(delegate { Hover(id, od); });
                            et.triggers.Add(hover);
                            Toggle toggle = option.GetComponentInChildren<Toggle>();
                            categories[id].options[od].OnToggleStart(texts[0], toggle);
                            toggle.onValueChanged.AddListener(delegate { categories[id].options[od].OnToggleChange(texts[0], toggle.isOn); });

                            //Add
                            optionsCategories[id][od] = option;
                            //Hide
                        }
                    }
                }

                //Select default one
                //SelectCategory(0);
            }

            public void SelectCategory(int id)
            {
                for (int i = 0; i < optionsCategories.Count; i++)
                {
                    for (int o = 0; o < optionsCategories[i].Length; o++)
                    {
                        optionsCategories[i][o].SetActive(id == i);
                    }
                }

                Hover(id, 0);
            }

            public void Hover(int cat, int id)
            {
                if (cat < categories.Length && id < categories[cat].options.Length)
                {
                    if (hoverInfo)
                    {
                        hoverInfo.text = categories[cat].options[id].GetHoverText();
                    }
                }
            }
        }
    }
}