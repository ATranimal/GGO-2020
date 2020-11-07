using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MochiDisplay : MonoBehaviour {

    public static int mochiCounter = 0;
    public Text mochiText;
    private int prevMochiCounter = -1;
    private string displayText = "No. of mochi: ";

    void Start() {
        mochiText.text = displayText + mochiCounter;
    }

    // Update is called once per frame
    void Update() {
        if (prevMochiCounter != mochiCounter) {
            mochiText.text = displayText + mochiCounter;
            prevMochiCounter = mochiCounter;
        }
    }
}

