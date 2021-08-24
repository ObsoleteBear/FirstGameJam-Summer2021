using UnityEngine;

public class Arrow : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0) && timeuntillarrow < Time.time)
        {
            airw();
            timeuntillarrow = Time.time + arrowpew;
        }
    }
    void airw()
    {
        float angle = cont.isFacingRight ? 0f : 180f;
        Instantiate(arrow, bow.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
