using System.Collections;
using System.Collections.Generic;
using NueGames.NueDeck.Scripts.Utils;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Managers
{
    public class RoomEventManager : MonoBehaviour
    {
        [SerializeField] private float comabtChance = 0.6f;
        [SerializeField] private float bossEncounterChance = 0.1f;
        [SerializeField] private List<MiscellaneousData> miscellaneousDataList;
        [SerializeField] private GameObject miscellaneousUI; 
        protected GameManager GameManager => GameManager.Instance;
        private UIManager UIManager => UIManager.Instance;
        private SceneChanger SceneChanger;

        public static RoomEventManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                transform.parent = null;
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
            SceneChanger = GetComponent<SceneChanger>();
        }

        public void EnterRoom()
        {
            float random = Random.Range(0f, 1f);
            switch (random)
            {
                case float n when n < comabtChance: // normal combat
                    GameManager.PersistentGameplayData.IsBossEncounter = false;
                    break;
                case float n when n < comabtChance + bossEncounterChance: // boss combat
                    GameManager.PersistentGameplayData.IsBossEncounter = true;
                    break;
                default: // Miscellaneous
                    Miscellaneous();
                    return;
            }
            SceneChanger.OpenCombatScene();
        }

        private void Miscellaneous()
        {
            int random = Random.Range(0, miscellaneousDataList.Count);
            MiscellaneousData miscellaneousData = miscellaneousDataList[random];
            UIManager.OpenMiscellaneous(miscellaneousData.Description, miscellaneousData.Image);
            miscellaneousData.InvokeFunction();
            UIManager.InformationCanvas.ResetCanvas();
            GameObject mapManager = GameObject.Find("MapManager"); // Find MapManager in the scene and update the button
            if (mapManager != null)
            {
                mapManager.GetComponent<MapManager>().UpdateButton(GameManager.PersistentGameplayData.CurrentEncounterId);
            }
        }
    }
}