using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {
    public float speed=4;
    Vector2 moveDir;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector2 cursorPos = Input.mousePosition;
        moveDir = cursorPos - rb.position;

        //Change vector values to be not weird
        if (moveDir.x>0){
            moveDir.x = 1;
        } else if (moveDir.x<0){
            moveDir.x = -1;
        }

        if (moveDir.y > 0){
            moveDir.y = 1;
        } else if (moveDir.y < 0){
            moveDir.y = -1;
        }
        Debug.Log(moveDir);
        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
    void Update () {
        rb.MovePosition(rb.position + (moveDir * speed * Time.deltaTime));
	}
}
