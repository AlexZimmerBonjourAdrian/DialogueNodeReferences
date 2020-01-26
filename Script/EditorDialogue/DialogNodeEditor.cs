using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System;
using DNECore;



public class DialogNodeEditor : EditorWindow
{
    private List<CNode> nodes;
    private Vector2 offset;
    private Vector2 drag;
   // private Toolbar toolbar;

    [MenuItem("Dialog Node Editor/Canvas")]
    private static void OpenWindow()
    {
        DialogNodeEditor window = GetWindow<DialogNodeEditor>();
        window.titleContent = new GUIContent("Dialog Node Editor");
    }
    /*
    private void OnEnable()
    {

    }
    */

        //TODO:Terminal La GUI
    private void OnGui()
    {
        DrawCanvas(20, 0.2f, Color.gray);
        DrawCanvas(100, 0.4f, Color.gray);
    }

    //Dibja los nodos
    private void DrawNodes()
    {
        //Recorre la lista comprobando que no sea null
        if(nodes != null)
        {
            //Reccorre los nodos y los dibuja 
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Draw();
            }
        }
    }

    //Dibuja el canvas de fondo del menu
    private void DrawCanvas(float gridSpacing, float gridOpacity, Color gridColor)
    {
        int widthdivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        offset += drag * 0.5f;
        Vector3 newoffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

        for (int i = 0; i < widthdivs; i++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newoffset, new Vector3(gridSpacing * i, position.height, 0f) + newoffset);
        }
        for (int i = 0; i < heightDivs; i++)
        {
            Handles.DrawLine(new Vector3(-gridSpacing * i, -gridSpacing, 0) + newoffset, new Vector3( position.width, gridSpacing * i, 0f) + newoffset);
        }
        
}
    /*
  private void DrawConnectionLine(Event e)
    {
        if)
    }
    */
}

    

       
    
    

