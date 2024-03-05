using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Rotation_test : MonoBehaviour
    {

        [SerializeField] private Projectile m_Start;
        [SerializeField] private Transform m_Target;

    
        // Update is called once per frame
        void Update()
        {
            rotationProjectile();
        }

        public void rotationProjectile()
        {
            Vector2.MoveTowards(m_Start.transform.position, m_Target.transform.position, Time.deltaTime);
        }
    }
}

