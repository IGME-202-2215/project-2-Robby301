using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public AsteroidSpawner spawnHitAsteroids;
    public TrackScoreAndLives tracker;

    public GameObject spaceShip;
    public GameObject gameOverText;

    public GameObject[] asteroids;
    public GameObject[] bullets;

    SpriteRenderer shipSprite;
    SpriteRenderer asteroidSprite;
    SpriteRenderer bulletSprite;

    // Start is called before the first frame update
    void Start()
    {
        shipSprite = spaceShip.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker.lives > 0)
        {
            asteroids = GameObject.FindGameObjectsWithTag("Rock");
            bullets = GameObject.FindGameObjectsWithTag("Bullet");

            foreach (GameObject asteroid in asteroids)
            {
                asteroidSprite = asteroid.GetComponent<SpriteRenderer>();
                if (
                (asteroidSprite.bounds.min.x < shipSprite.bounds.max.x) &&
                (asteroidSprite.bounds.max.x > shipSprite.bounds.min.x) &&
                (asteroidSprite.bounds.max.y > shipSprite.bounds.min.y) &&
                (asteroidSprite.bounds.min.y < shipSprite.bounds.max.y)
                )
                {
                    //Debug.Log("SHIP HIT");
                    Destroy(asteroid);
                    tracker.lives -= 1;
                }
                else
                {
                    shipSprite.color = Color.white;
                    asteroidSprite.color = Color.white;
                }
            }

            foreach (GameObject asteroid in asteroids)
            {
                asteroidSprite = asteroid.GetComponent<SpriteRenderer>();

                foreach (GameObject bullet in bullets)
                {
                    bulletSprite = bullet.GetComponent<SpriteRenderer>();

                    if (
                    (asteroidSprite.bounds.min.x < bulletSprite.bounds.max.x) &&
                    (asteroidSprite.bounds.max.x > bulletSprite.bounds.min.x) &&
                    (asteroidSprite.bounds.max.y > bulletSprite.bounds.min.y) &&
                    (asteroidSprite.bounds.min.y < bulletSprite.bounds.max.y)
                    )
                    {
                        /*Debug.Log("BULLET HIT");
                        bulletSprite.color = Color.red;
                        asteroidSprite.color = Color.red;*/
                        Destroy(bullet);
                        spawnHitAsteroids.AsteroidHit(asteroid);
                    }
                    else
                    {
                        bulletSprite.color = Color.white;
                        asteroidSprite.color = Color.white;
                    }
                }
            }
        }
        else
        {
            GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Rock");

            foreach(GameObject asteroid in allAsteroids)
            {
                Destroy(asteroid);
            }

            GameObject[] allBullets = GameObject.FindGameObjectsWithTag("Bullet");

            foreach (GameObject bullet in allBullets)
            {
                Destroy(bullet);
            }

            Destroy(spaceShip);

            gameOverText.SetActive(true);
        }
    }
}