using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorDrawerLayout {

    private static GUIStyle ToggleButtonStyleNormal = null;
    private static GUIStyle ToggleButtonStyleToggled = null;

    public static bool ToggleButton(string label, bool val) {
        if (ToggleButtonStyleNormal == null)
        {
            ToggleButtonStyleNormal = "Button";
            ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
            ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
        }
        if (GUILayout.Button(label,
                             val ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        {
            return !val;
        }
        return val;
    }
}
