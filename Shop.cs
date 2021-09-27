using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentProperties gun_turrent;
    BuildManager bm;
     void Start()
    {
         bm = BuildManager.instance;
    }
    public void buyGunTurrent() {
        Debug.Log("Gun Turrent");
        bm.setTurrent(gun_turrent);
    }
}
