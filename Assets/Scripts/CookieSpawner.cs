using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CookieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_EntityPrefab;
        [SerializeField] private CircleArea m_Area;
        [SerializeField] private int m_NumSpawns;
        [SerializeField] private float m_RespawnTime;
        [SerializeField] private float m_RandomSpeed;

        private float m_Timer;

        private void Start()
        {
            m_Timer = m_RespawnTime;
            for (int i = 0; i < m_NumSpawns; i++)
            {
                SpawnEntities();
            }
        }

        private void Update()
        {
            if (m_Timer > 0)
            {
                m_Timer -= Time.deltaTime;
            }

            if(m_Timer <= 0)
            {
                SpawnEntities();
                m_Timer = m_RespawnTime;
            }
        }

        private void SpawnEntities()
        {
            int index = Random.Range(0, m_EntityPrefab.Length);
            GameObject debris = Instantiate(m_EntityPrefab[index].gameObject);

            debris.transform.position = m_Area.GetRandomInsideZone();

            
            Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();

            if (rb != null && m_RandomSpeed > 0)
            {
                rb.velocity = (Vector2)UnityEngine.Random.insideUnitSphere * m_RandomSpeed;
            }
            
        }
    }
}

