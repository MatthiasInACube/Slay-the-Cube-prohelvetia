using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class ContainerCreationAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.CreateContainer;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (CollectionManager != null) { 
                CollectionManager.CreateCardsById("11_toxic_gas_container", Mathf.RoundToInt(actionParameters.Value));
            }
            else
                Debug.LogError("There is no CollectionManager");
            
            if (FxManager != null)
                FxManager.PlayFx(actionParameters.SelfCharacter.transform, FxType.Buff);

            if (AudioManager != null) 
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }
    }
}