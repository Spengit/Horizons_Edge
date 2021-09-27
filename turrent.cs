using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    [Header("Setup")]
    private Transform target;
    public Transform rota;
    
    [Header("Turrent Attributes")]
    public float range = 20f;
    public float fire_speed = 2f;
    private float reload_time = 0f;

    public GameObject bullet;
    public Transform fire_Point;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] nmes = GameObject.FindGameObjectsWithTag("enemy");

        float shortDist = Mathf.Infinity;
        GameObject nearNme = null;

        foreach (GameObject nme in nmes)
        {
            float distToNme = Vector3.Distance(transform.position, nme.transform.position);
            if(distToNme < shortDist)
            {
                shortDist = distToNme;
                nearNme = nme;
            }
        }

        if(nearNme != null && shortDist <= range)
        {
            target = nearNme.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
            //turrent lock on
            Vector3 pointLook = target.position - transform.position;

            Quaternion lookRotate = Quaternion.LookRotation(pointLook);

        Vector3 rotation = Quaternion.Lerp(rota.rotation, lookRotate, Time.deltaTime * 10f).eulerAngles;
        rota.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(reload_time <= 0f)
        {
            Shoot();
            reload_time = 1f / fire_speed;
        }

        reload_time -= Time.deltaTime;
    }

    void Shoot() {
        // Debug.Log("Shoot");

        GameObject bullet_obj = (GameObject)Instantiate(bullet, fire_Point.position, fire_Point.rotation);
        Bullet b = bullet_obj.GetComponent<Bullet>();

        if(b!= null)
        {
            b.Seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
