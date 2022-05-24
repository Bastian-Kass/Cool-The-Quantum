using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{

    [SerializeField]
    public List<GameObject> GameTools;
    public LinkedList<GameObject> _GameTools_linked = new LinkedList<GameObject>();

    private LinkedListNode<GameObject> ActiveToolNode;

    void Start()
    {

        LinkedListNode<GameObject> tool_node;

        // Creating Linked list
        foreach( GameObject tool in GameTools){
            tool.SetActive(false);
            tool_node = new LinkedListNode<GameObject>(tool);
            _GameTools_linked.AddLast(tool_node);
        }

        //Setting the
        ActiveToolNode = _GameTools_linked.First;
        ActiveToolNode.Value.SetActive(true);

    }

    public void SelectNextTool(){
        ActiveToolNode.Value.SetActive(false);

        ActiveToolNode = ActiveToolNode.Next ?? ActiveToolNode.List.First;

        ActiveToolNode.Value.SetActive(true);
    }

    public void SelectPreviousTool(){
        ActiveToolNode.Value.SetActive(false);

        ActiveToolNode = ActiveToolNode.Previous ?? ActiveToolNode.List.Last;
        
        ActiveToolNode.Value.SetActive(true);
    }

    public GameObject GetActiveTool(){
        return ActiveToolNode.Value;
    }




}
