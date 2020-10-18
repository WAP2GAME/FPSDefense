using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class mLogWindow : MonoBehaviour
{
    private Text lotText = null;

    private ScrollRect scroll_rect = null;

    void Start()
    {
        logText = GameObject.Find("log_Text").GetComponent<Text>();
        scroll_rect = GameObject.Find("Scroll_View").GetComponent<scroll_rect>();

        if (logText != null)
            logText.text += "Hello Log Window!" + "\n";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lotText.text += "Mouse down position (" + "X:" + Input.mousePosition.x + "Y:" + Input.mousePosition.y + "\n";

            scroll_rect.verticalNormalizedPosition = 0.0f;
        }
    }
}
