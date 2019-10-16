using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Origin.UI;
using TMPro;

public class UIElement_InGameScreen : UIElement {

    public TextMeshProUGUI levelIDLabel;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI attemptsLabel;
    public Transform signsTransform;
    public GameObject signReference;

    public override void Awake () {
        base.Awake();
        GameEvents.UpdateSigns.Subscribe("Update Signs", UpdateSigns);
        levelIDLabel.text = Config.stagePrefix;
    }

    private void Update () {
        scoreLabel.text = "Score: " + Analytics.score.ToString();
        attemptsLabel.text = "Attempts: " + Analytics.attempts.ToString();
    }

    private void UpdateSigns () {
        foreach (Transform sign in signsTransform) {
            Destroy (sign.gameObject);
        }
        for (int i = 0; i < Config.spawns; i++) {
            Instantiate (signReference, signsTransform);
        }
    }

    private void OnDestroy () {
        GameEvents.UpdateSigns.Unsubscribe("Update Signs", UpdateSigns);
    }
}
