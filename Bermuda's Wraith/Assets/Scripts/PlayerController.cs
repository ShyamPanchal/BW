using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    public float moveSpeed = 5;
    public float jumpPower = 300;
    private bool isJumping = false;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpPower);
            isJumping = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

}
