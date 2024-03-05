using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerupSave : Powerup
    {

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AddSave(0);
        }

    }
}

