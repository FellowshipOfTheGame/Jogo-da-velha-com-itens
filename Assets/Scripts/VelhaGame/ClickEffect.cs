using Unity.VisualScripting;
using UnityEngine;

public static class ClickEffect
{
        public enum ClickEffectType
        {
                NormalClick,
                Eraser,
                Protect,
                Power4,
                //...
        }
        public enum ClickActor
        {
                Player1,
                Player2,
        }

        private static ClickActor _currClickActor = 
                ClickActor.Player1;
        
        private static ClickEffectType _clickEffect = 
                ClickEffectType.NormalClick;
        
        public static void PassTurn()
        {
                if(_currClickActor == ClickActor.Player1)
                        _currClickActor = ClickActor.Player2;
                else 
                        _currClickActor = ClickActor.Player1;
        }

        public static ClickEffectType GetCurrSelectionMode() => 
                _clickEffect;

        public static void SetClickMode(ClickEffectType clickEffect) =>
                _clickEffect = clickEffect;
        
        public static void ResetSelectionMode() =>
                _clickEffect = ClickEffectType.NormalClick;
        
        public static ClickActor GetCurrPlayer() => 
                _currClickActor;
}