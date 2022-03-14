using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public TrackScoreAndLives tracker;

    public Camera gameCamera;
    public GameObject asteroid;

    private float cameraWidth;
    private float cameraHeight;
    private int timeCheck = 0;
    private int asteroidScale;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = gameCamera.orthographicSize;
        cameraWidth = cameraHeight * gameCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeCheck)
        {
            timeCheck += 5;
            for(int i = 0; i < 3; i++)
            {
                Instantiate(asteroid);

                asteroidScale = Random.Range(0, 2);
                //Debug.Log(asteroidScale);

                if (asteroidScale == 1)
                {
                    asteroid.transform.localScale = new Vector3(2, 2, 1);
                }
                else if (asteroidScale == 0)
                {
                    asteroid.transform.localScale = new Vector3(1, 1, 1);
                }

                int topOrBottom = Random.Range(0, 2);
                float leftOrRight = Random.Range(-cameraWidth, cameraWidth);

                if (topOrBottom == 1)
                {
                    asteroid.transform.position = new Vector3(leftOrRight, (cameraHeight + 2), 0);
                    asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(135f, 225f));
                }
                else if (topOrBottom == 0)
                {
                    asteroid.transform.position = new Vector3(leftOrRight, (-cameraHeight - 2), 0);
                    asteroid.transform.rotation = Quaternion.Euler(0, 0, (Random.Range(45f, 135f) + 270f));
                }
            }
        }
    }

    public void AsteroidHit(GameObject hitAsteroid)
    {
        int numOfAsteroids = Random.Range(2, 4);

        if (hitAsteroid.transform.localScale.x == 2)
        {
            for(int i = 1; i <= numOfAsteroids; i++)
            {
                GameObject newAsteroid = Instantiate(asteroid);
                newAsteroid.transform.position = hitAsteroid.transform.position;
                newAsteroid.transform.localScale = new Vector3(1, 1, 1);
                newAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            }

            Destroy(hitAsteroid);

            tracker.score += 10;
        }
        else if (hitAsteroid.transform.localScale.x == 1)
        {
            for (int i = 1; i <= numOfAsteroids; i++)
            {
                GameObject newAsteroid = Instantiate(asteroid);
                newAsteroid.transform.position = hitAsteroid.transform.position;
                newAsteroid.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                newAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            }

            Destroy(hitAsteroid);

            tracker.score += 20;
        }
        else
        {
            Destroy(hitAsteroid);

            tracker.score += 30;
        }
    }
}