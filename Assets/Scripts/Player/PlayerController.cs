using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool move;
    private float horizontalInput;
    private float verticalInput;
    private float lastHorizontalInput;
    private float lastVerticalInput;

    public Animator animator;

    //Awake is called when the script instance is being loaded
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Move", move);

        animator.SetFloat("X", lastHorizontalInput);
        animator.SetFloat("Y", lastVerticalInput);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        move = true;
        if (horizontalInput != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            lastHorizontalInput = horizontalInput;
            lastVerticalInput = 0;
        }
        else if (verticalInput != 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
            lastVerticalInput = verticalInput;
            lastHorizontalInput = 0;
        }
        else
        {
            move = false;
        }
    }
}
