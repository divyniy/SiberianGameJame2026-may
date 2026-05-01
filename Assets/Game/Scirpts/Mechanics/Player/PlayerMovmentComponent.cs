using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovmentComponent : IPlayerComponent
{
    /// REFERENCES
    private Transform player;
    private Rigidbody rb;
    private PlayerConfig config;
    private Transform orientation;
    private Transform body;

    // CFG VARIABLES
    private float speed;
    private AnimationCurve curve;
    private LayerMask mask;

    //MOVMENT LOGIC
    private float x;
    private float y;
    private Vector3 direction;
    private bool isGrounded;

    public PlayerMovmentComponent(Transform player, Rigidbody rb, Transform orientation, Transform body)
    {
        this.rb = rb;
        this.player = player;
        this.orientation = orientation;
        this.body = body;

        config = Resources.Load<PlayerConfig>("PlayerConfig");

        speed = config.speed;
        curve = config.curve;
        mask = config.groundMask;
    }

    public void FixedUpdate()
    {
        isGrounded = Physics.Raycast(orientation.transform.position, -orientation.transform.up, orientation.localScale.y + 0.2f, mask);
        MyInput();

        Move();
        Rotate();
    }
    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        direction = new Vector3(x, 0 ,y);
        direction = orientation.transform.forward * direction.z + orientation.transform.right * direction.x;

        direction = direction.normalized * speed;

        

        if(isGrounded)
        {
            Vector3 slope = GetSlopeNormal();
            direction = Vector3.ProjectOnPlane(direction, GetSlopeNormal()).normalized*speed;
        }
        

        rb.MovePosition((direction * Time.fixedDeltaTime)  + rb.position);
    }

    private void Rotate()
    {
        Vector3 currentSlopeNormal = GetSlopeNormal();
        if (direction.magnitude <= 0.001f) return;

        Vector3 up = (isGrounded && currentSlopeNormal != Vector3.zero) ? currentSlopeNormal : Vector3.up;

        Vector3 forward = direction.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(forward, up);
        body.rotation = Quaternion.RotateTowards(body.rotation, targetRotation, 1000f * Time.fixedDeltaTime);
    }

    private Vector3 GetSlopeNormal()
    {
        RaycastHit hit;
        
        Vector3 forward = orientation.forward;

        Debug.DrawRay(orientation.transform.position, -orientation.transform.up, Color.red, orientation.localScale.y + 0.8f);

        Physics.Raycast(orientation.transform.position, -orientation.transform.up, out hit, orientation.localScale.y + 0.5f, mask);
       
        if(hit.transform != null)
        {
            return hit.normal;
        }

        return Vector3.zero;
    }

}






public interface IPlayerComponent
{
    
}