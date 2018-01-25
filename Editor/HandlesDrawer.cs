using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class HandlesDrawer {

    public static Vector2 DoPointHandle(SceneView sceneView, Vector2 cp)
    {
        return DoPositionHandle(sceneView, cp, 15f, Handles.CircleHandleCap);
    }

    public static Vector2 DoControlHandle(SceneView sceneView, Vector2 cp)
    {
        return DoPositionHandle(sceneView, cp, 7.5f, Handles.RectangleHandleCap);
    }

    public static Vector2 DoPositionHandle(SceneView sceneView, Vector2 cp, float size, Handles.CapFunction capFunction)
    {
        //var centrePos = sceneView.camera.WorldToScreenPoint(Vector3.zero);
        var worldPoint = cp.to3D();// sceneView.camera.ScreenToWorldPoint(centrePos + cp.to3D());
        var ret = Handles.Slider2D(worldPoint,
                         Vector3.forward, Vector3.up, Vector3.right,
                         /*HandleUtility.GetHandleSize(Vector3.zero) */ size, capFunction, Vector2.zero);
        return ret.to2D();
    }
}
