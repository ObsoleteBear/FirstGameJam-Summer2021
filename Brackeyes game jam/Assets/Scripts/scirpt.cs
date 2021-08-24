//C# Example (LookAtPoint.cs)
using UnityEngine;
public class scirpt : MonoBehaviour
{
    public Vector3 lookAtPoint = Vector3.zero;

    void Update()
    {
        transform.LookAt(lookAtPoint);
    }
}