using UnityEngine;

public class FlameBoi : MonoBehaviour
{
    public float flamepew = 0.2f;
    public Controller cont;
    public Collider2D FlameCol;
    public SpriteRenderer FlameRend;
    private void Awake()
    {   
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopShoot();
        }
    }
   void Shoot()
    {
        FlameCol.enabled = true;
        FlameRend.enabled = true;
        cont.Speed = 3.5f;
    }
    void StopShoot()
    {
        FlameCol.enabled = false;
        FlameRend.enabled = false;
        cont.Speed = 7f;
    }
}
