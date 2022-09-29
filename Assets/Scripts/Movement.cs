using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))) {
            // run
            // animator.SetFloat("Speed", 1);
            animator.SetBool("Speed", true);
            transform.position = (Vector2)transform.position + new Vector2(-5, 0) * Time.deltaTime;
            sr.flipX = true;
        }
        else if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D))) {
            // animator.SetFloat("Speed", 1);
            animator.SetBool("Speed", true);
            transform.position = (Vector2)transform.position + new Vector2(5, 0) * Time.deltaTime;
            sr.flipX = false;
        }
        else {
            // animator.SetFloat("Speed", 0);
            animator.SetBool("Speed", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // jump
            if (animator.GetBool("CanJump") == true) {
                animator.SetTrigger("Jump");
                rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }

            animator.SetBool("CanJump", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("CanJump", true);
        }
    }
}