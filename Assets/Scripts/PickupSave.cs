using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class PickupSave : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_UiWarning;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();
        
            if(ship != null)
            {
                Destroy(gameObject);
                Destructible.freezing = true;
                m_UiWarning.Invoke();
            }
        }
    }

}

