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
        if (this.cameraTrackTarget != null)
        {
            var newPosition = Vector2.Lerp(this.transform.position, this.cameraTrackTarget.position,
                Time.deltaTime * this.trackingSpeed);
            var camPosition = new Vector3(newPosition.x, newPosition.y, this.cameraZDepth);

            var v3 = camPosition;

            var newX = v3.x;
            var newY = v3.y;

            if (!(this.minX == 0 && this.maxX == 0 && this.minY == 0 && this.maxY == 0))
            {
                newX = Mathf.Clamp(v3.x, this.minX, this.maxX);
                newY = Mathf.Clamp(v3.y, this.minY, this.maxY);
            }

            this.transform.position = new Vector3(newX, newY, this.cameraZDepth);
        }
    }
}