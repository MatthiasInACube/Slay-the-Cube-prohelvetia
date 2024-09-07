using System;
using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace NueGames.NueDeck.Scripts.UI
{
    public class EncounterButton : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Button button;
        [SerializeField] private Image completedImage;
        [SerializeField] private bool isFinal;
        private RoomEventManager RoomEventManager => RoomEventManager.Instance;
        
        protected GameManager GameManager => GameManager.Instance;
        private int roomNumber;
        
        private void Awake()
        {
            completedImage.gameObject.SetActive(false);
        }

        public void SetRoomNumber(int targetRoomNumber)
        {
            roomNumber = targetRoomNumber;
        }

        public void setCurrentEncounter()
        {
            GameManager.PersistentGameplayData.CurrentEncounterId = roomNumber;
        }

        public void EnterRoom()
        {
            RoomEventManager.EnterRoom();
        }
        
        public void SetStatus(EncounterButtonStatus targetStatus)
        {
            switch (targetStatus)
            {
                case EncounterButtonStatus.Active:
                    button.interactable = true;
                    if (isFinal) GameManager.PersistentGameplayData.IsFinalEncounter = true;
                    
                    break;
                case EncounterButtonStatus.Passive:
                    button.interactable = false;
                    break;
                case EncounterButtonStatus.Completed:
                    button.interactable = false;
                    completedImage.gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetStatus), targetStatus, null);
            }
        }
    }
}