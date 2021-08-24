using UnityEngine.SceneManagement;
using UnityEngine;
public class scirpt : MonoBehaviour
{
    public float speed;

    private Transform target;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
        if (collision.collider.tag == "Arrow")
        {
            SceneManager.LoadScene(3);
        }
    }
}
