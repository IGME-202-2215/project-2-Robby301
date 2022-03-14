using UnityEngine;

public class AsteroidMove : MonoBehaviour
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
        if ((Mathf.Abs(gameObject.transform.position.y) > (cameraHeight + 5)) || (Mathf.Abs(gameObject.transform.position.y) < (-cameraHeight - 5)))
        {
            Destroy(gameObject);
        }
        else if ((Mathf.Abs(gameObject.transform.position.x) > (cameraWidth + 5)) || (Mathf.Abs(gameObject.transform.position.x) < (-cameraWidth - 5)))
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += 3 * (transform.up * Time.deltaTime);
        }
    }
}