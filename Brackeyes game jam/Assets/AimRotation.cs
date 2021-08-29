using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    public bool isEnemy;
    public GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.GetComponentInParent<Controller>().isEnemy == true)
        {
            isEnemy = true;
        }
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemy == false)
        {
            Vector2 RightStick = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (RightStick != Vector2.zero)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(RightStick.x, (RightStick.y)) * -180f / Mathf.PI + 90f);
            }
        }else
        {
            Vector3 targetPosition = Player.transform.position;
            Vector3 dir = targetPosition - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
