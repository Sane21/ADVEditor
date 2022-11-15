using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ADVEditorWindow : EditorWindow
{
    private SampleGraphView _graph;

    [MenuItem("Window/Open ADVEditorWindow")]
    public static void Open()
    {
        var graphEditor = CreateInstance<ADVEditorWindow>();
        graphEditor.Show();
        graphEditor.titleContent = new GUIContent("ADVEditorサンプル");

        // GetWindow<ADVEditorWindow>("ADVEditorWindow");
    }

    private void OnEnable()
    {
        CreateGraphView();
    }

    private void CreateGraphView()
    {
        _graph = new SampleGraphView();
        // 子の要素の追加、ノードを配置する土台となるGraphViewを配置する
        rootVisualElement.Add(_graph);
    }
}
