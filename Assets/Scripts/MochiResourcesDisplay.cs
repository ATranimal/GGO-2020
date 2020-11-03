using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MochiResourcesDisplay : MonoBehaviour {
    
    private int mochiResources = 0;
    public Text mochiResourcesText;

    // Update is called once per frame
    void Update() {
        mochiResourcesText.text = "No. of mochi resources: " + mochiResources;
    }
}
