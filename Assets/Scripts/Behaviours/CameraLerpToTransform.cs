using UnityEngine;

public class CameraLerpToTransform : MonoBehaviour
{
    public Transform cameraTrackTarget;

    public float cameraZDepth = -10f;

    public float maxX;

    public float maxY;

    public float minX;

    public float minY;

    public float trackingSpeed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTrackTarget != null)
        {
            var newPosition = Vector2.Lerp(transform.position, cameraTrackTarget.position,
                Time.deltaTime * trackingSpeed);
            var camPosition = new Vector3(newPosition.x, newPosition.y, cameraZDepth);

            var v3 = camPosition;

            var newX = v3.x;
            var newY = v3.y;

            if (!(minX == 0 && maxX == 0 && minY == 0 && maxY == 0))
            {
                newX = Mathf.Clamp(v3.x, minX, maxX);
                newY = Mathf.Clamp(v3.y, minY, maxY);
            }

            transform.position = new Vector3(newX, newY, cameraZDepth);
        }
    }
}