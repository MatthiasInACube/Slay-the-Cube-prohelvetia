using System.Collections.Generic;
using NueGames.NueDeck.Scripts.Card;
using NueGames.NueDeck.Scripts.Data.Collection;
using NueGames.NueDeck.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NueGames.NueDeck.Scripts.UI
{
    public class MiscellaneousCanvas : CanvasBase
    {
        [SerializeField] private TextMeshProUGUI descriptionTextField;
        [SerializeField] private Image image;

        public void ChangeDescription(string newTitle) => descriptionTextField.text = newTitle;
        
        public void SetImage(Sprite newSprite) => image.sprite = newSprite; 

        public override void OpenCanvas()
        {
            base.OpenCanvas();
            if (CollectionManager)
                CollectionManager.HandController.DisableDragging();
        }

        public override void CloseCanvas()
        {
            base.CloseCanvas();
            if (CollectionManager)
                CollectionManager.HandController.EnableDragging();
        }

        public override void ResetCanvas()
        {
            base.ResetCanvas();
        }
    }
}
