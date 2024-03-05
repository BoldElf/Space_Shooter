using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class Invis : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_OffInvis;
        static public bool Invisble;

        private float time;
        private void Update()
        {
            if(Invisble == true)
            {
                time += Time.deltaTime;

                if(time > 5.0f)
                {
                    Invisble = false;
                    m_OffInvis.Invoke();
                }
            }
        }


    }
}

