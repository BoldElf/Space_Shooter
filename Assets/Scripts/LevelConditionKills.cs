using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    
    public class LevelConditionKills : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int ScoreKills;
        private bool m_Reached;
        
        bool ILevelCondition.IsComleted
        {
            get
            {
                if(Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if(Player.Instance.NumKills >= ScoreKills)
                    {
                        m_Reached = true;
                    }
                    
                }
                
                return m_Reached;
                
            }
            
        }
        
    }
}

