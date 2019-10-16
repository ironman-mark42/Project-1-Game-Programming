using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Origin.UI;

public class AdvancedUIManager : UIManager {

    public override void Awake () {
        base.Awake();
        GameEvents.TitleScreen.Subscribe ("Show Title Screen", ()=>ShowUIE ("UIElement_TitleScreen"));
        GameEvents.InGameScreen.Subscribe ("Show InGame Screen", ()=>ShowUIE ("UIElement_InGameScreen"));
        GameEvents.EndGame.Subscribe ("Show Score Screen", ()=>ShowUIE ("UIElement_ScoreScreen"));
        GameEvents.StageNameScreen.Subscribe ("Show Stage Name Screen", ()=>ShowOverlayUIE ("UIElement_StageNameScreen"));
    }
}
