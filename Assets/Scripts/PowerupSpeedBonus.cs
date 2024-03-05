using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerupSpeedBonus : Powerup
    {
        [SerializeField] private float m_BonusSpeed;
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AddSpeed(m_BonusSpeed);
        }
    }
}
