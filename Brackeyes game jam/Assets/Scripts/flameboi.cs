using UnityEngine;

public class flameboi : MonoBehaviour
{
    public float flamepew = 0.2f;
    public Transform mouth;
    public GameObject flame;
    private float timeuntillflame;
    Controller cont;
    private void Start()
    {
        cont = gameObject.GetComponent<Controller>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && timeuntillflame < Time.time)
        {
            Shoot();
            timeuntillflame = Time.time + flamepew;
        }
    }
   void Shoot()
    {
        float angle = cont.isFacingRight ? 0f : 180f;
        Instantiate(flame, mouth.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
