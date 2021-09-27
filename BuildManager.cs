
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurrentProperties turrent_to_build;
    public GameObject default_turrent;
    // to build missle launcher
    public GameObject missle_turrent;
    public static BuildManager instance;
  

     void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

   public bool canBuild { get { return turrent_to_build != null; } }
   public bool hasMoney { get { return PlayerStatus.player_money >= turrent_to_build.cost; } }

    public void setTurrent(TurrentProperties turr) {
        turrent_to_build = turr;
    }

    public void buildTurrentOn(Node n)
    {
        if(PlayerStatus.player_money < turrent_to_build.cost)
        {
            return;
        }

        PlayerStatus.player_money -= turrent_to_build.cost;
       GameObject turrent = (GameObject)Instantiate(turrent_to_build.tur, n.getPosOffset(), Quaternion.identity);

        n.turrent = turrent;
    }
}
