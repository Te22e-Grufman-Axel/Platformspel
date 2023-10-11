using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class BOBcontroller : MonoBehaviour
{
    [SerializeField]
    float jumpforce = 1200;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    LayerMask groundlayer;
    bool hasrelsedjump = true;
    Rigidbody2D rbody;
    [SerializeField]
    float groundradius = 0.2f;

    Vector2 footposition;
    Vector2 bottomcolidersize = new Vector2.zero;


    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        bottomcolidersize
    }



    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);

        footposition = transform.position;

        // bool isGrounded = Physics2D.OverlapCircle(getfoot(), groundradius, groundlayer);
        bool isGrounded = Physics2D.OverlapBox(getfoot(),getfootzise(),groundlayer);

        if (Input.GetAxisRaw("Jump") > 0 && hasrelsedjump == true && isGrounded)
        {
            rbody.AddForce(Vector2.up * jumpforce);
            hasrelsedjump = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasrelsedjump = true;
        }
    }


private Vector2 getfootzise()
{
return new Vector2(GetComponent<Rigidbody2D>().Bounds.size
}

    private Vector2 getfoot()
    {
       float hight = GetComponent <Collider2D>().bounds.size.y;
        return transform.position + Vector3.down * hight / 2;
    }
    void OnDrawGizmos()
    {
            Gizmos.DrawWireCube(bottomcolidersize);
    }





}
