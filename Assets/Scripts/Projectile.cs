using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    
    public class Projectile : Entity
    {
        [SerializeField] private float m_Velocity;
        [SerializeField] private float m_Lifetime;
        [SerializeField] private int m_Damage;
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;
        //[SerializeField] private Vector3 Target;
        [SerializeField] private CircleArea m_CircleArea_01;
        private float m_Timer;

        private bool isPlayerProjectile;

        void Update()
        {
            float stepLength = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLength;

            RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up, stepLength);

            if(m_Parent == Player.Instance.ActiveShip)
            {
                isPlayerProjectile = true;
            }

            if(hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();
               
                
                if(dest != null && dest != m_Parent)
                {
                    dest.AplayDamage(m_Damage);

                    if(isPlayerProjectile == true)
                    {
                        isPlayerProjectile = false;
                        Player.Instance.AddScore(dest.ScoreValue);
                    }
                }

                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            m_Timer += Time.deltaTime;

            if(m_Timer > m_Lifetime)
            {
                Destroy(gameObject);
            }

            transform.position += new Vector3(step.x, step.y,0);
            //TransformExt.LookAt2D(transform,Target);

            if(m_CircleArea_01 != null)
            {
                OnProjectileLifeEnd1(hit.collider, hit.point);
            }
            

        }
        protected virtual void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Destroy(gameObject);
        }

        private Destructible m_Parent;
        public Destructible Parent => m_Parent;

        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }

        public void OnProjectileLifeEnd1(Collider2D col, Vector2 pos)
        {
            var colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, m_CircleArea_01.Radius);
            foreach (var collider in colliders)
            {
                CheckAsteroid dest = collider.transform.root.GetComponent<CheckAsteroid>();

                if (dest != null && dest != Parent)
                {
                    TransformExt.LookAt2D(transform, dest);
                }
                //!
            }
        }
    }
}

