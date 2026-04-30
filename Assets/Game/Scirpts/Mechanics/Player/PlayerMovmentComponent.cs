using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovmentComponent : IPlayerComponent
{
    /// REFERENCES
    private Transform player;
    private Rigidbody rb;
    private PlayerConfig config;

    // CFG VARIABLES
    private float speed;
    private AnimationCurve curve;
    private LayerMask mask;

    //MOVMENT LOGIC
    private float x;
    private float y;
    private Vector3 direction;
    private bool isGrounded;

    public PlayerMovmentComponent(Transform player, Rigidbody rb)
    {
        this.rb = rb;
        this.player = player;

        config = Resources.Load<PlayerConfig>("PlayerConfig");

        speed = config.speed;
        curve = config.curve;
        mask = config.groundMask;
    }

    public void FixedUpdate()
    {
        isGrounded = Physics.Raycast(player.transform.position, -player.transform.up, player.localScale.y + 0.2f, mask);
        MyInput();

        Move();
    }
    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        direction = new Vector3(x, 0 ,y);
        direction = player.transform.forward * direction.z + player.transform.right * direction.x;

        direction = direction.normalized * speed;

        Vector3 slope = GetSlopeNormal();

        if(isGrounded)
        {
            direction = Vector3.ProjectOnPlane(direction, GetSlopeNormal()).normalized*speed;
            Debug.Log(slope);

            Quaternion targetQuartion = slope != Vector3.zero ? Quaternion.FromToRotation(Vector3.up, slope) : Quaternion.identity;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetQuartion, curve.Evaluate(0.55f));
        }
        

        rb.MovePosition((direction * Time.fixedDeltaTime)  + rb.position);
    }

    
    private Vector3 GetSlopeNormal()
    {
        RaycastHit hit;
        Physics.Raycast(player.transform.position, -player.transform.up, out hit, player.localScale.y + 0.5f, mask);
       
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