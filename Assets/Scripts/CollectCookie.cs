using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CollectCookie : Powerup
    {
        [SerializeField] private int score;
        protected override void OnPickedUp(SpaceShip ship)
        {
            CookieCounter Cookie = ship.transform.root.GetComponent<CookieCounter>();

            if(Cookie != null)
            {
                Cookie.AddCookie();
                Player.Instance.AddScore(score);

            }
        }
    }
}

