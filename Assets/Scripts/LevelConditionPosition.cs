using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        private bool m_Reached;
        [SerializeField] private int score;

        [SerializeField] FinishPoint target;
        
        bool ILevelCondition.IsComleted
        {
            get
            {
                if (target.enter)
                {
                    m_Reached = true;
                    Player.Instance.AddScore(score);
                }    
      
                return m_Reached;
            }
        }
    }
}


