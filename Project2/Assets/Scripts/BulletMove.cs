using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(gameObject.transform.position.x) > 150) || (Mathf.Abs(gameObject.transform.position.y) > 150))
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += 20 * (transform.up * Time.deltaTime);
        }
    }
}
