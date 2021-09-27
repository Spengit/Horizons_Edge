using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController cc;
    public Transform cam;
    private Vector3 move;
    private float xDir, yDir;
    private float speed = 8f;
    public float smooth = 0.1f;
    float smoothVel;
   

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        move = new Vector3(xDir, 0f, yDir).normalized;
        if(move.magnitude >= 0.1f)
        {
            float moveToMouse = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, moveToMouse, ref smoothVel, smooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, moveToMouse, 0f) * Vector3.forward;

            cc.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
