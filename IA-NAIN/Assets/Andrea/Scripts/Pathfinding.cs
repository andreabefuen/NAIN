using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {


    Grid grid;

    public Transform StartPosition;
    public Transform TargetPosition;



    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FindPath(StartPosition.position, TargetPosition.position);
	}


    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Nodo StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Nodo TargetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Nodo> OpenList = new List<Nodo>();
        HashSet<Nodo> ClosedList = new HashSet<Nodo>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Nodo CurrentNode = OpenList[0];
            for(int i = 1; i <OpenList.Count; i++)
            {
                if(OpenList[i].fCost < CurrentNode.fCost || OpenList[i].fCost == CurrentNode.fCost && OpenList[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }

            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if(CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            foreach( Nodo NeighborNode in grid.GetNeighboringNodes(CurrentNode))
            {
                if(!NeighborNode.IsWall || ClosedList.Contains(NeighborNode))
                {
                    continue;
                }

                int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighborNode);


                if(MoveCost < NeighborNode.gCost || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.gCost = MoveCost;
                    NeighborNode.hCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.Parent = CurrentNode;

                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }

        }

    }

    void GetFinalPath(Nodo a_StartingNode, Nodo a_EndNode)
    {
        List<Nodo> FinalPath = new List<Nodo>();
        Nodo CurrentNode = a_EndNode;


        while(CurrentNode != a_StartingNode){
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;

        }

        FinalPath.Reverse();
        grid.FinalPath = FinalPath;
    }


    public int GetManhattenDistance(Nodo a_nodoA, Nodo a_nodoB)
    {
        int ix = Mathf.Abs(a_nodoA.gridX - a_nodoB.gridX);
        int iy = Mathf.Abs(a_nodoA.gridY - a_nodoB.gridY);

        return ix + iy;
    }


}
