using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 RightStick = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(RightStick != Vector2.zero)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(RightStick.x, (RightStick.y)) * -180f / Mathf.PI + 90f);
        }
    }
}
