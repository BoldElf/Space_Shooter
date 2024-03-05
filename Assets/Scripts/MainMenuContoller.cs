using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuContoller : SingletonBase<MainMenuContoller>
    {
        [SerializeField] private SpaceShip m_DefaultSpaceShip;
        [SerializeField] private GameObject m_EpisodeSelection;
        [SerializeField] private GameObject m_ShipSelection;

        [SerializeField] StatsPanelController StatsController;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultSpaceShip;
        }

        public void OnSelectShip()
        {
            m_ShipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonStartNew()
        {
            m_EpisodeSelection.SetActive(true);

            gameObject.SetActive(false);
        }

        public void OnButtonExit()
        {
            Application.Quit();
        }

        public void OnButtonStats()
        {
            StatsController.ShowStats();
        }
    }
}
