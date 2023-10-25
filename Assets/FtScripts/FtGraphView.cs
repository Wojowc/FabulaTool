using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;


public class FtGraphView : GraphView
{
    private readonly Vector2 defaultNodeSize = new Vector2(300, 400);

    public FtGraphView()
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        AddElement(GenerateEntryPointNode());
    }

    private Port GeneratePort(FtGraphNode node, Direction dir, Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, dir, capacity, typeof(float));
    }

    private FtGraphNode GenerateEntryPointNode()
    {
        FtGraphNode node = new FtGraphNode
        {
            title = "start",
            GUID = System.Guid.NewGuid().ToString(),
            nodeText = "Attenzion",
            isEntry = true
        };

        Port newPort = GeneratePort(node, Direction.Output, Port.Capacity.Single);
        newPort.portName = "Next";
        node.outputContainer.Add(newPort);

        newPort = GeneratePort(node, Direction.Output, Port.Capacity.Single);
        newPort.portName = "Next2";
        node.outputContainer.Add(newPort);

        node.RefreshExpandedState();
        node.RefreshPorts();

        node.SetPosition(new Rect(100, 200, 100, 150));

        return node;
    }

    public void CreateNode(string name)
    {
        AddElement(CreateFullNode(name));
    }

    public FtGraphNode CreateFullNode(string nodeName)
    {
        FtGraphNode node = new FtGraphNode
        {
            title = nodeName,
            GUID = System.Guid.NewGuid().ToString(),
            nodeText = "Attenzion"
        };

        Port inputPort = GeneratePort(node, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        node.inputContainer.Add(inputPort);

        node.RefreshExpandedState();
        node.RefreshPorts();
        node.SetPosition(new Rect(Vector2.zero, defaultNodeSize));

        return node;    
    }

}
