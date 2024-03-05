using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundary";

        [SerializeField] private float m_VelocityDamageModifire;
        [SerializeField] public float m_DamageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag) return;

            var destructible = transform.root.GetComponent<Destructible>();

            if(destructible != null)
            {
                destructible.AplayDamage((int)m_DamageConstant + (int)(m_VelocityDamageModifire * collision.relativeVelocity.magnitude));
            }
        }

    }
}

