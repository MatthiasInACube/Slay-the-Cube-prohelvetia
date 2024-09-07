using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class GassedAction: CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Gassed;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (!actionParameters.TargetCharacter) return;
            
            var targetCharacter = actionParameters.TargetCharacter;
            var selfCharacter = actionParameters.SelfCharacter;
            
            var value = actionParameters.Value + selfCharacter.CharacterStats.StatusDict[StatusType.GasAmplification].StatusValue;
            if (actionParameters.CardData.Id == "11_toxic_gas_container") // Apply compressed toxic gas buff if the card is toxic gas container
            {
                value += selfCharacter.CharacterStats.StatusDict[StatusType.ToxicCompression].StatusValue;
            }
            
            targetCharacter.CharacterStats.ApplyStatus(StatusType.Gassed, Mathf.RoundToInt(value));

            if (FxManager != null)
            {
                FxManager.PlayFx(actionParameters.TargetCharacter.transform,FxType.Gassed);
                FxManager.SpawnFloatingText(actionParameters.TargetCharacter.TextSpawnRoot,value.ToString());
            }
           
            if (AudioManager != null) 
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }
    }
}