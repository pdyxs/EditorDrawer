using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorDrawer {

    public delegate void ButtonPushedDelegate();
    public delegate void TogglePushedDelegate(bool val);

    public const float DEFAULT_HEIGHT = 20;
    public const float BOX_PADDING = 5;

    private static GUIStyle ToggleButtonStyleNormal = null;
    private static GUIStyle ToggleButtonStyleToggled = null;

    public static Rect WithHeight(Rect pos, float height) {
        return new Rect(pos.x, pos.y, pos.width, height);
    }

    public static Rect FromHeight(Rect pos, float height)
    {
        return new Rect(pos.x, pos.y + height, pos.width, pos.height - height);
    }

    public static Rect PropertyField(Rect pos, SerializedProperty property, string child)
    {
        return PropertyField(pos, property.FindPropertyRelative(child));
    }

    public static Rect PropertyField(Rect pos, SerializedProperty property)
    {
        var height = EditorGUI.GetPropertyHeight(property);
        EditorGUI.PropertyField(
            WithHeight(pos, height),
            property
        );
        return FromHeight(pos, height);
    }

    public static Rect DefaultButton(Rect pos, string label, ButtonPushedDelegate action)
    {
        return Button(pos, label, Color.white, DEFAULT_HEIGHT, action);
    }

    public static Rect DefaultButton(Rect pos,
                              string label,
                              Color colour,
                              ButtonPushedDelegate action)
    {
        return Button(pos, label, colour, DEFAULT_HEIGHT, action);
    }

    public static Rect Button(Rect pos, string label, ButtonPushedDelegate action) {
        return Button(pos, label, Color.white, pos.height, action);
    }

    public static Rect Button(Rect pos, 
                              string label, 
                              Color colour,
                              ButtonPushedDelegate action)
    {
        return Button(pos, label, colour, pos.height, action);
    }

    public static Rect Button(Rect pos,
                              string label,
                              float height,
                              ButtonPushedDelegate action)
    {
        return Button(pos, label, Color.white, height, action);
    }

    public static Rect Button(Rect pos,
                              string label,
                              Color colour,
                              float height,
                              ButtonPushedDelegate action)
    {
        var c = GUI.color;
        GUI.color = colour;
        if (GUI.Button(WithHeight(pos, height), label))
        {
            action();
        }
        GUI.color = c;
        return FromHeight(pos, height);
    }

    public static float ArrayHeight(SerializedProperty property) {
        float height = 0;
        for (int i = 0; i != property.arraySize; ++i) {
            height += EditorGUI.GetPropertyHeight(property.GetArrayElementAtIndex(i));
        }
        return height;
    }

    public static Rect Box(Rect pos) {
        GUI.Box(pos, "");
        return new Rect(pos.x + BOX_PADDING, pos.y + BOX_PADDING,
                        pos.width - BOX_PADDING * 2,
                        pos.height - BOX_PADDING * 2);
    }

    public static Rect ToggleButton(Rect pos, 
                                    string label, 
                                    bool val, 
                                    TogglePushedDelegate action)
    {
        return ToggleButton(pos, label, val, Color.white, pos.height, action);
    }

    public static Rect ToggleButton(Rect pos,
                                    string label,
                                    bool val,
                                    Color colour,
                                    TogglePushedDelegate action)
    {
        return ToggleButton(pos, label, val, colour, pos.height, action);
    }

    public static Rect ToggleButton(Rect pos,
                                    string label,
                                    bool val,
                                    float height,
                                    TogglePushedDelegate action)
    {
        return ToggleButton(pos, label, val, Color.white, height, action);
    }

    public static Rect ToggleButton(Rect pos,
                                    string label,
                                    bool val,
                                    Color colour,
                                    float height,
                                    TogglePushedDelegate action)
    {
        if (ToggleButtonStyleNormal == null)
        {
            ToggleButtonStyleNormal = "Button";
            ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
            ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
        }
        var c = GUI.color;
        GUI.color = colour;
        if (GUI.Button(WithHeight(pos, height), label,
                       val ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        {
            action(!val);
        }
        GUI.color = c;
        return FromHeight(pos, height);
    }
}
