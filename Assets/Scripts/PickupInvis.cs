using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class PickupInvis : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpriteRenderer ship = collision.transform.GetComponent<SpriteRenderer>();

            if (ship != null)
            {
                Invis.Invisble = true;
                Destroy(gameObject);
                ship.gameObject.SetActive(false);
            }
        }
    }
}




