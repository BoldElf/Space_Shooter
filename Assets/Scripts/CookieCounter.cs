using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CookieCounter : MonoBehaviour
    {
        private int m_cookie;


        public void AddCookie()
        {
            m_cookie++;

        }

        public void DeCookie()
        {
            m_cookie -= m_cookie;
        }

        public int SumCookie()
        {
            return m_cookie;
        }

    }
}

