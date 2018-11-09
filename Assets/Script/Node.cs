using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

	public int gridX; //X position in Node Array
	public int gridY; //Y position in Node Array
	public bool IsWall; //Tells whether this node is being obstructed
	public Vector3 Position; //the world position of the node
	public Node Parent; // For the ASar algorithm, will storer what node it previously came from 
						//so it can trace the shortest path.
	public int gCost; //The cost of moving to the next square
	public int hCost; // the distance to the goal fom this node
	//quick get function to add the H Cost and the G Cost
	public int FCost { get { return gCost + hCost; } }

	public Node(bool a_IsWall, Vector3 a_Pos, int a_gridX, int a_gridY){
		IsWall = a_IsWall;
		Position = a_Pos;
		gridX = a_gridX;
		gridY = a_gridY;
	}


}
