using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MarsFPSKit
{
    /// <summary>
    /// This is used for <see cref="Kit_PvP_GMB_Deathmatch"/>
    /// </summary>
    public class Kit_DeathmatchHUD : Kit_GameModeHUDBase
    {
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _obj;

        private int roundedRestSeconds;
        private int displaySeconds;
        private int displayMinutes;

        bool isTime = false;

        public override void HUDUpdate(Kit_IngameMain main)
        {
            if(isTime || roundedRestSeconds >= 200) 
            {
                isTime = true;
                _obj.SetActive(false);
                return;
            }

            if (main.currentPvPGameModeBehaviour.AreEnoughPlayersThere(main) || main.hasGameModeStarted)
            {
                roundedRestSeconds = Mathf.CeilToInt(main.timer);
                displaySeconds = roundedRestSeconds % 60; //Get seconds
                //displayMinutes = roundedRestSeconds / 60; //Get minutes
                                                          //Update text
                timer.text = string.Format("{0:0}", displaySeconds);
                _image.fillAmount = roundedRestSeconds / 5f;
                _obj.SetActive(true);
            }
            else
            {
                _obj.SetActive(false);
            }
        }
    }
}
