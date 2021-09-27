
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject shell;
    public float bullet_speed = 50f;
    public int bullet_damage = 40;

    public void Seek(Transform _target)
    {
        target = _target;


    }


    // Update is called once per frame
    void Update()
    {
        
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float frame_dist = bullet_speed * Time.deltaTime;

        if(dir.magnitude <= frame_dist)
        {
            HitMarker();
            return;
        }
        transform.Translate(dir.normalized * frame_dist, Space.World);
    }

     void HitMarker()
    {
        GameObject shelling = (GameObject)Instantiate(shell, transform.position, transform.rotation);
        damage();
        Destroy(shelling, 1.5f);
       
       
    }

    void damage()
    {

      Enemy  v = target.GetComponent<Enemy>();
        v.takeDamage(bullet_damage);
        
    }


}
