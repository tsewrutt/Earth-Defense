using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*#pragma warning disable CS0138 // Variable is declared but never used
using WayPoint
#pragma warning restore CS0138 // Variable is declared but never used
*/
[CustomEditor(typeof(WayPoint))]
public class WayPointFollower : Editor
{
    WayPoint Waypt => target as WayPoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.blue;
        for (int i = 0; i < Waypt.pts.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 currwaypt = Waypt.currentPos + Waypt.pts[i];
            Vector3 newwaypt = Handles.FreeMoveHandle(currwaypt, Quaternion.identity, 0.7f,
                new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            GUIStyle txtStyle = new GUIStyle();
            txtStyle.fontStyle = FontStyle.Bold;
            txtStyle.fontSize = 20;
            txtStyle.normal.textColor = Color.white;

            Vector3 txtAllignment = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(Waypt.currentPos + Waypt.pts[i] + txtAllignment, $"{i + 1}", txtStyle);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Waypt.pts[i] = newwaypt - Waypt.currentPos;
            }

        }
    }
}
