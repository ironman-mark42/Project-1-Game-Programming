using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Origin.UI;
using TMPro;

public class UIElement_ScoreScreen : UIElement {

    public TextMeshProUGUI scoreLabel;
    public Button menuButton;
    public Button replayButton;

    public override void Awake () {
        base.Awake();
        menuButton.onClick.AddListener (()=>GameEvents.FadeToEvent(GameEvents.TitleScreen));
        replayButton.onClick.AddListener (()=>GameEvents.FadeToEvent(GameEvents.StartGame));
    }

    private void Start () {
        Debug.Log(Analytics.score);
        scoreLabel.text = Analytics.score.ToString();
        Analytics.Reset();
    }
}
