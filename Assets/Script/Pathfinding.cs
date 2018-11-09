using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
	Grid grid;
	public Transform TargetPosition;

	GameObject[] enemies;

	private void Awake(){
		grid = GetComponent<Grid> ();
	}

	private void Update(){
		enemies = GameObject.FindGameObjectsWithTag ("enemies");
		foreach (GameObject enemy in enemies) {
			Transform enemyPos = enemy.gameObject.transform;
			FindPath (enemyPos.position, TargetPosition.position);
		}
	}

	void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos){
		Node startNode = grid.NodeFromWorldPosition (a_StartPos);
		Node targetNode = grid.NodeFromWorldPosition (a_TargetPos);

		List<Node> OpenList = new List<Node> ();
		HashSet<Node> ClosedList = new HashSet<Node> ();

		OpenList.Add (startNode);

		while (OpenList.Count > 0) {
			Node CurrentNode = OpenList [0];
			for (int i = 1; i < OpenList.Count; i++) {
				if (OpenList [i].FCost < CurrentNode.FCost || OpenList [i].FCost == CurrentNode.FCost && OpenList [i].hCost < CurrentNode.hCost) {
					CurrentNode = OpenList [i];
				}
			}
			OpenList.Remove (CurrentNode);
			ClosedList.Add (CurrentNode);

			if (CurrentNode == targetNode) {
				GetFinalPath (startNode, targetNode);
			}

			foreach (Node NeighborNode in grid.GetNeighboringNodes(CurrentNode)) {
				if (!NeighborNode.IsWall || ClosedList.Contains (NeighborNode)) {
					continue;
				}
				int MoveCost = CurrentNode.gCost + GetManhattenDistance (CurrentNode, NeighborNode);

				if (MoveCost < NeighborNode.gCost || !OpenList.Contains (NeighborNode)) {
					NeighborNode.gCost = MoveCost;
					NeighborNode.hCost = GetManhattenDistance (NeighborNode, targetNode);
					NeighborNode.Parent = CurrentNode;

					if (!OpenList.Contains (NeighborNode)) {
						OpenList.Add (NeighborNode);
					}
				}
			}
		}
	}

	void GetFinalPath(Node a_StartingNode, Node a_EndNode){
		List<Node> FinalPath = new List<Node> ();
		Node CurrentNode = a_EndNode;

		while (CurrentNode != a_StartingNode) {
			FinalPath.Add (CurrentNode);
			CurrentNode = CurrentNode.Parent;
		}

		FinalPath.Reverse ();

		grid.FinalPath = FinalPath;
	}

	int GetManhattenDistance(Node a_NodeA, Node a_NodeB){
		int ix = Mathf.Abs (a_NodeA.gridX - a_NodeB.gridX);
		int iy = Mathf.Abs (a_NodeA.gridY - a_NodeB.gridY);

		return ix + iy;

	}

}
