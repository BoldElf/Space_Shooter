using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class StatsPanelController : MonoBehaviour
    {
        [SerializeField] private Text m_GolbalKills;
        [SerializeField] private Text m_GlobalScore;

        public PlayerStatistics PlayerLevel;

        private void Update()
        {
            if (Input.GetKeyDown("f1"))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        public void ShowStats()
        {
            gameObject.SetActive(true);

            int TotalKills = PlayerPrefs.GetInt("TotalKills");
            int TotalScore = PlayerPrefs.GetInt("TotalScore");

            m_GolbalKills.text = "TotalKills: " + TotalKills.ToString();
            m_GlobalScore.text = "TotalScore: " + TotalScore.ToString();

        }

        public void CloseStats()
        {
            gameObject.SetActive(false);
            MainMenuContoller.Instance.gameObject.SetActive(true);
        }
        /*
        private void Calculate()
        {
            GlobalKills += PlayerLevel.numKills;
            GlobalKills += PlayerLevel.score;
        }
        */
    }
}

