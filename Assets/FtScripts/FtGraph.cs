using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.EditorTools;
using UnityEngine.UIElements;

public class Graph : EditorWindow
{
    private FtGraphView ftGraphView;

    [MenuItem("Graph/MainGraph")]
    public static void OpenGraphWindow()
    {
        EditorWindow window = GetWindow<Graph>();
        window.titleContent = new GUIContent ("My Graph");
        window.Show();
    }



    private void OnEnable()
    {
        ConstructGraphView();
        GenerateToolbar();
    }

    private void ConstructGraphView()
    {
        ftGraphView = new FtGraphView
        {
            name = "Mein Graph"
        };

        ftGraphView.StretchToParentSize();
        rootVisualElement.Add(ftGraphView);
    }

    private void GenerateToolbar()
    {
        var toolbar = new EditorToolbarDropdown ();
        EditorToolbarButton createNewNodeButton = new EditorToolbarButton(() =>
        {
            ftGraphView.CreateNode("My Creatied Node");
        });
        createNewNodeButton.text = "Create Node";
        toolbar.Add(createNewNodeButton);
        rootVisualElement.Add(toolbar);
    }

    private void OnDisable()
    {
        rootVisualElement.Remove(ftGraphView);
    }
}
