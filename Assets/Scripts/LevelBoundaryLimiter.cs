using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace SpaceShooter
{
    /// <summary>
    /// Ограничитель позиции. Работает в связке со скриптом LevelBoundary если такой имеется на сцене.
    /// Кидается на объект который надо ограничить.
    /// </summary>
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        [SerializeField] public UnityEvent m_OffTrail;
        [SerializeField] public UnityEvent m_OnTrail;
        private bool m_checkTeleport = false;
        private float m_time;

        private void Update()
        {
            

            if (LevelBoundary.Instance == null) return;

            var lb = LevelBoundary.Instance;
            var r = lb.Radius;

            if(transform.position.magnitude > r)
            {
                if(lb.LimitMode == LevelBoundary.Mode.Limit)
                { 
                    transform.position = transform.position.normalized * r;
                }

                if (lb.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    m_OffTrail.Invoke();
                    transform.position = -transform.position.normalized * r;
                    m_checkTeleport = true;
                }
            }

            if(m_checkTeleport == true)
            {
                m_time += Time.deltaTime;
            }

            if(m_time >= 0.5f)
            {
                m_OnTrail.Invoke();
                m_checkTeleport = false;
                m_time = 0.0f;
            }

        }
    }
}

