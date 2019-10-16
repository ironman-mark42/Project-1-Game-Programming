using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Origin.UI;

public class UIElement_TitleScreen : UIElement {

    public Button startButton;

    public override void Awake () {
        base.Awake();
         startButton.onClick.AddListener (()=>GameEvents.FadeToEvent(GameEvents.StartGame));
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) GameEvents.FadeToEvent(GameEvents.StartGame);
    }
}
