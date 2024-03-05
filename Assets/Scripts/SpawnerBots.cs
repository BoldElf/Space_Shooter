using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class SpawnerBots : MonoBehaviour
    {
        public enum SpawnMode
        {
            Start,
            Loop
        }

        [SerializeField] private Entity[] m_EntityPrefab;
        [SerializeField] private Entity[] m_EntityPrefab_01;

        [SerializeField] private CircleArea m_Area;
        [SerializeField] private SpawnMode m_SpawnMode;

        [SerializeField] private int m_NumSpawns;
        [SerializeField] private float m_RespawnTime;

        private float m_Timer;

        private void Start()
        {
            if (m_SpawnMode == SpawnMode.Start)
            {
                SpawnTeam_01();
                SpawnTeam_02();
            }

            m_Timer = m_RespawnTime;
        }

        private void Update()
        {
            if (m_Timer > 0)
            {
                m_Timer -= Time.deltaTime;
            }

            if (m_SpawnMode == SpawnMode.Loop && m_Timer < 0)
            {
                SpawnTeam_01();
                SpawnTeam_02();
                m_Timer = m_RespawnTime;
            }
        }

        private void SpawnTeam_01()
        {
            for (int i = 0; i < m_NumSpawns; i++)
            {
                GameObject e1 = null;

                int index = Random.Range(0, m_EntityPrefab.Length);
                GameObject e = Instantiate(m_EntityPrefab[index].gameObject);
                e.transform.position = m_Area.GetRandomInsideZone();

                if (e1 == e)
                {
                    Destroy(e);
                    e = Instantiate(m_EntityPrefab_01[index].gameObject);
                    e.transform.position = m_Area.GetRandomInsideZone();
                    e1 = e;
                }
                e1 = e;
            }
        }

        private void SpawnTeam_02()
        {
            for (int i = 0; i < m_NumSpawns; i++)
            {
                GameObject e1 = null;

                int index = Random.Range(0, m_EntityPrefab_01.Length);
                GameObject e = Instantiate(m_EntityPrefab_01[index].gameObject);
                e.transform.position = m_Area.GetRandomInsideZone();
                
                if(e1 == e)
                {
                    Destroy(e);
                    e = Instantiate(m_EntityPrefab_01[index].gameObject);
                    e.transform.position = m_Area.GetRandomInsideZone();
                }
                e1 = e;
            }
        }
    }
}



