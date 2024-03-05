using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter{
    public class FinishPoint : MonoBehaviour
    {
        [HideInInspector] public bool enter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            var point = collision.transform.root.GetComponent<CheckPlayer>();

            if(point != null)
            {
                enter = true;
            }
            
            //enter = true;

        }
    }
}

