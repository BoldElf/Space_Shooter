using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionCookie : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int m_ScoreCookie;
        public int ScoreCookie => m_ScoreCookie;

        private bool m_Reached;

        

        bool ILevelCondition.IsComleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    CookieCounter cookie = Player.Instance.ActiveShip.transform.root.GetComponent<CookieCounter>();

                    if(cookie != null)
                    {
                        if (cookie.SumCookie() >= ScoreCookie)
                        {
                            m_Reached = true;
                        }
                    }
                    

                }

                return m_Reached;

            }

        }
    }
}

