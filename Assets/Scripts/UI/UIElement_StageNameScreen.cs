using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Origin.UI;
using TMPro;


public class UIElement_StageNameScreen : UIElement {

    public TextMeshProUGUI label;

    public override void Awake () {
        base.Awake ();
        label.text = Config.stagePrefix;
    }
}
