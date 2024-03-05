using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class UICooike : MonoBehaviour
    {
        [SerializeField] Text TextCookie;
        [SerializeField] LevelConditionCookie levelConditionCookie;

        private void Update()
        {
            AddText();
        }

        public void AddText()
        {
            if(levelConditionCookie != null)
            {
                CookieCounter cookieCounter = Player.Instance.ActiveShip.transform.root.GetComponent<CookieCounter>();
                //TextCookie.text = "Remains to collect:" + cookieCounter.SumCookie().ToString();
                int abc = levelConditionCookie.ScoreCookie - cookieCounter.SumCookie();

                TextCookie.text = "Remains to collect:" + abc.ToString();
            }
            
        }

   }
}
