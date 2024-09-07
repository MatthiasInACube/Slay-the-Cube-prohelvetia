using System.Collections.Generic;
using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.UI;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Managers
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private List<EncounterButton> encounterButtonList;

        public List<EncounterButton> EncounterButtonList => encounterButtonList;
        
        private GameManager GameManager => GameManager.Instance;
        
        private void Start()
        {
            GameManager.PersistentGameplayData.InitRooms(encounterButtonList.Count);
            PrepareEncounters();
        }
        
        private void PrepareEncounters()
        {
            for (int i = 0; i < EncounterButtonList.Count; i++)
            {
                var btn = EncounterButtonList[i];
                btn.SetRoomNumber(i);
                if (GameManager.PersistentGameplayData.IsRoomCleared(i))
                    btn.SetStatus(EncounterButtonStatus.Completed);
                else {
                    // check if any neighbour is completed - its a 5x5 grid in the array
                    if ((i == 0)
                        || (i % 5 != 0 && GameManager.PersistentGameplayData.IsRoomCleared(i - 1))
                        || (i % 5 != 4 && GameManager.PersistentGameplayData.IsRoomCleared(i + 1))
                        || (i > 4 && GameManager.PersistentGameplayData.IsRoomCleared(i - 5))
                        || (i < 20 && GameManager.PersistentGameplayData.IsRoomCleared(i + 5))
                        )
                        btn.SetStatus(EncounterButtonStatus.Active);
                    else
                        btn.SetStatus(EncounterButtonStatus.Passive);
                }
            }
        }

        public void UpdateButton(int roomNumber)
        {
            EncounterButtonList[roomNumber].SetStatus(EncounterButtonStatus.Completed);
            GameManager.PersistentGameplayData.SetRoomCleared(roomNumber);
            PrepareEncounters();
        }
    }
}
