
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float pan_speed = 30f;
    public float pan_buffer = 10f;
    public float scroll_speed = 5000f;
    private bool moving = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            moving = !moving;

        if (!moving)
            return;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - pan_buffer)
        {
            transform.Translate(Vector3.forward * pan_speed * Time.deltaTime, Space.World);
        } 
        if(Input.GetKey("s") || Input.mousePosition.y <=  pan_buffer)
        {
            transform.Translate(Vector3.back * pan_speed * Time.deltaTime, Space.World);
        } 
        if(Input.GetKey("a") || Input.mousePosition.x <= pan_buffer)
        {
            transform.Translate(Vector3.left * pan_speed * Time.deltaTime, Space.World);
        } 
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - pan_buffer)
        {
            transform.Translate(Vector3.right * pan_speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * scroll_speed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, 10, 80);

        transform.position = pos;
    }

}
