using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;
using HarapekoADV;

public class SampleNode : Node
{
    protected virtual string Title => "title";
    public SampleNode()
    {
        title = "サンプル";

        // var text = new UnityEngine.UIElements.TextField("テキスト");
        // mainContainer.Add(text);

        var visualTree = Resources.Load<VisualTreeAsset>("parameterContainer.xml");
        if (visualTree != null)
            Debugger.Log(visualTree.ToString());
        else Debugger.Log("null");
        visualTree.CloneTree(mainContainer);
    }
}