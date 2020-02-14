using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DNECore;


namespace DNECore
{

    public class Toolbar
    {
        /*
        private CDialogueNodeEditor editor;
        private Rect rect;
        private bool clickedSave;
        private bool clickedSaveAs;
        private bool clickedLoad;
        private bool clickedBuild;
        private bool ClickedMoveToStart;
        private string path;
        private string message;

        public Toolbar(CDialogueNodeEditor editor)
        {
            this.editor = editor;
            rect = new Rect(0, 0, editor.position.width, 500);
        }
        public void Draw()
        {
            rect.width = editor.position.width;

            GUILayout.BeginArea(rect, EditorStyles.toolbar);

            GUILayout.BeginHorizontal();
            clickedSave = GUILayout.Button(new GUIContent("Save"), EditorStyles.toolbarButton, GUILayout.Width(50));
            clickedSaveAs = GUILayout.Button(new GUIContent("Save As"), EditorStyles.toolbarButton, GUILayout.Width(50));
            clickedLoad = GUILayout.Button(new GUIContent("Load"), EditorStyles.toolbarButton, GUILayout.Width(100));
            clickedBuild = GUILayout.Button(new GUIContent("Build"), EditorStyles.toolbarButton, GUILayout.Width(100));
            ClickedMoveToStart = GUILayout.Button(new GUIContent("Move to Start"), EditorStyles.toolbarButton, GUILayout.Width(100));

            if (path != null)
            {
                float width = (new GUIStyle()).CalcSize((new GUIContent(path))).x;
                GUILayout.Label(path, GUILayout.Width(width + 20f));
            }
            GUILayout.FlexibleSpace();
            if (message != null)
            {
                float width = (new GUIStyle()).CalcSize((new GUIContent(message))).x;
                GUILayout.Label(message, GUILayout.Width(width + 20f));
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        
      public void processEvents(Event e)
        {
            if(clickedSave)
            {
                if(path != null)
                {
                    string status = editor
                }
            }
        }
        */
        /*
        private void ProcessSaveAs()
        {
            string local_path = EditorUtility.SaveFilePanelInProject("Save Canvas", "Camvas.asset","asset", "");
            if(local_path.Length > 0)
                
        }
        */
    }
}
