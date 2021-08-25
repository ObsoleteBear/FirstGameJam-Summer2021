using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float arrowpew = 0.2f;
    public Transform bow;
    public GameObject arrow;
    private float timeuntillarrow;
    Controller cont;
    private void Start()
    {
        cont = gameObject.GetComponent<Controller>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && timeuntillarrow < Time.time)
        {
            airw();
            timeuntillarrow = Time.time + arrowpew;
        }
    }
    void airw()
    {
        
        Instantiate(arrow, bow.position, Quaternion.Euler(new Vector3(0f, 0f)));
    }
}
