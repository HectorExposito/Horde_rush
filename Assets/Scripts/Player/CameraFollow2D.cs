using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    private void LateUpdate()
    {
        float followPosx = target.position.x;
        float followPosy = target.position.y;

        transform.position = new Vector3(followPosx, followPosy,transform.position.z);
    }
}
