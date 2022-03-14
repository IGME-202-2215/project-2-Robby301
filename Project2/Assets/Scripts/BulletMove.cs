using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float cameraWidth;
    private float cameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(gameObject.transform.position.y) > (cameraHeight + 1)) || (Mathf.Abs(gameObject.transform.position.y) < (-cameraHeight - 1)))
        {
            Destroy(gameObject);
        }
        else if ((Mathf.Abs(gameObject.transform.position.x) > (cameraWidth + 1)) || (Mathf.Abs(gameObject.transform.position.x) < (-cameraWidth - 1)))
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += 20 * (transform.up * Time.deltaTime);
        }
    }
}