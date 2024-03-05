using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CheckAsteroid : MonoBehaviour
    {
        [SerializeField] private Destructible m_DebrisPrefabSmall;
        [SerializeField] private float m_RandomSpeed;

        private void Start()
        {
            for(int i = 0; i < 2;i++)
            {
                gameObject.GetComponent<Destructible>().EventOnDeath.AddListener(SpawnSmall);
            }
            
        }

        private void SpawnSmall()
        {
            GameObject test = Instantiate(m_DebrisPrefabSmall.gameObject);
            test.transform.position = transform.position;

            Rigidbody2D rb = test.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                rb.velocity = (Vector2)UnityEngine.Random.insideUnitSphere * m_RandomSpeed;
            }

        }
    }
}

