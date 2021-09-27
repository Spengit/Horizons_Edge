using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color hover_Color = Color.yellow;
    [Header("Optional")]
    public GameObject turrent;
    private Renderer rend;
    private Color org_color;
    BuildManager bm;

     void Start()
    {
        rend = GetComponent<Renderer>();
        org_color = rend.material.color;
        bm = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!bm.canBuild)
            return;
        if (bm.hasMoney)
        {
            rend.material.color = hover_Color;
        } else
        {
            rend.material.color = Color.red;
        }
    }

     void OnMouseExit()
    {
        rend.material.color = org_color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!bm.canBuild)
            return;

        if (turrent != null) {
            Debug.Log("Full");
            return;
        }

        bm.buildTurrentOn(this);

       


    }
    public Vector3 getPosOffset()
    {
        return transform.position;
    }


}
