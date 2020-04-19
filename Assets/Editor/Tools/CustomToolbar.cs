using UnityEditor;
using UnityEngine;

namespace EditorExtend
{
    [InitializeOnLoad]
    public static class CustomToolbar
    {
        static CustomToolbar()
        {
            ToolbarExtend.OnLeftToolbarGUI += OnLeftGUI;
        }

        private static void OnLeftGUI()
        {
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(new GUIContent("G", "Start Game"), ToolbarExtend.GetCommandButtonStyle()))
            {
                EditorPrefs.SetBool(URLSetting.START_IS_GAME, true);
                EditorApplication.ExecuteMenuItem("Edit/Play");
            }
        }
    }
}