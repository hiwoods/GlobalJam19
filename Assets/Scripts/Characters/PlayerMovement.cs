using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    bool IsGrounded
    {
        get
        {
            var castOrigin = transform.position - new Vector3(0, _controller.height/2f, 0);
            //Debug.Log(castOrigin.y);
            //Debug.Log(Physics.Raycast(castOrigin, -Vector3.up, 0.1f));
            //Debug.DrawRay(castOrigin, -Vector3.up * 0.1f, Color.red);
            return Physics.Raycast(castOrigin, -Vector3.up, 0.1f);
        }
    }

    void Update()
    {
        float gravity = 0;
        if (!IsGrounded)
        {
            gravity = -9.81f * Time.deltaTime;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * speed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log($"player hit something {hit.gameObject.name}");
    }
}
