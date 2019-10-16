using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Origin.World;

public class AdvancedWorldManager : World {

    public override void Awake () {
        base.Awake ();
        GameEvents.StartGame.Subscribe ("Go To Stage 00", ()=>InitStage(Config.stagePrefix));
    }

    private void Start () {
        Analytics.Reset();
        GameEvents.FadeToEvent(GameEvents.TitleScreen);

    }

    private void InitStage (string id) {
        MiseEnScene(id);
        Config.isGameAvailable = true;
    }
}
