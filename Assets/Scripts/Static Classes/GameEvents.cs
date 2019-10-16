using UnityEngine;
using System.Collections;
using Origin.Runtime;
using Origin.UI;
using UnityEngine.Events;

public static class GameEvents {

    public static CustomEvent StartApplication = new CustomEvent();

    public static CustomEvent StartGame = new CustomEvent();
    public static CustomEvent EndGame = new CustomEvent();

    public static CustomEvent StageNameScreen = new CustomEvent();
    public static CustomEvent TitleScreen = new CustomEvent();
    public static CustomEvent InGameScreen = new CustomEvent();
    public static CustomEvent ScoreScreen = new CustomEvent();

    public static CustomEvent UpdateSigns = new CustomEvent();

    private static UIAnimationFader UIFader;
    public static void FadeToEvent (CustomEvent action) {
        UIFader = UIManager.instance.ShowUIE ("Fader").gameObject.GetComponent<UIAnimationFader>();
        UIFader.inTheDarkAction = action.Publish;
        UIFader.inTheLightAction = UIFader.Remove;
        UIFader.ToTheDark();
        UIFader = null;
    }

    private static Branch branch;
    public static void Branch (string text = "", UnityAction positiveAction = null, UnityAction negativeAction = null) {
        branch = UIManager.instance.ShowOverlayUIE ("Branch").gameObject.GetComponent<Branch>();
        branch.Init (text, positiveAction, negativeAction);
    }
}
