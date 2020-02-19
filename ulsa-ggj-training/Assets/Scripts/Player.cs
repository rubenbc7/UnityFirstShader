using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    
    [SerializeField, Range(0f,20f)]

    float movespeed = 15f;
    [SerializeField, Range(0f,20f)]

    float jumpForce = 7f;
    Rigidbody2D rb2D;
[SerializeField ]
     Color rayColor = Color.magenta;
    [SerializeField, Range(0f,20f)]
    float rayDistance;
    [  SerializeField]
    LayerMask groundLayer;


void Awake(){
    rb2D = GetComponent<Rigidbody2D>();
}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * movespeed * Time.deltaTime);
        if(Grounding){
 if(JumpButton){ 
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
            }
        }
           
    }

    Vector2 Axis{
        get => new Vector2( Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

    }

    bool JumpButton{
        get => Input.GetButtonDown("Jump");
    }

    bool Grounding{
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

}