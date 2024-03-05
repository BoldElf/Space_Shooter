using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class UIWin : MonoBehaviour
    {
        [SerializeField]private UnityEvent m_Win;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_Win.Invoke();
            collision.transform.root.gameObject.SetActive(false);
        }
        
    }
}

