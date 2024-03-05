using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class AutoProjectile : MonoBehaviour
    {
        [SerializeField] private float m_Velocity;
        [SerializeField] private float m_Lifetime;
        [SerializeField] private int m_Damage;
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;
        [SerializeField] private GameObject target_ship;

        private float m_Timer;

        void Update()
        {
            float stepLength = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLength;
            Vector2 end = transform.position - target_ship.transform.position;


            RaycastHit2D hit = Physics2D.Raycast(transform.position, end , stepLength);

            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != null && dest != m_Parent)
                {
                    dest.AplayDamage(m_Damage);
                }
                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            m_Timer += Time.deltaTime;

            if (m_Timer > m_Lifetime)
            {
                Destroy(gameObject);
            }

            transform.position += new Vector3(step.x, step.y, 0);
        }
        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Destroy(gameObject);
        }

        private Destructible m_Parent;

        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }
    }
}

