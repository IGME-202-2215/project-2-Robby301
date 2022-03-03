using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;

    SpriteRenderer shipSprite;
    SpriteRenderer asteroidSprite;

    bool aABBCollision = true;
    bool circleCollision = false;

    float shipRadius = 0.7f;
    float asteroidRadius = 1f;
    float distance;

    [SerializeField]
    Text currentCollision;

    // Start is called before the first frame update
    void Start()
    {
        currentCollision.text = "AABB Collision";
        float distance = Mathf.Pow((shipRadius + asteroidRadius), 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (aABBCollision)
        {
            if(AABBCollision(spaceShip, asteroid1))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid1.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else if(AABBCollision(spaceShip, asteroid2))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid2.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else if(AABBCollision(spaceShip, asteroid3))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid3.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.white;

                asteroidSprite = asteroid1.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;

                asteroidSprite = asteroid2.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;

                asteroidSprite = asteroid3.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;
            }
        }

        if (circleCollision)
        {
            if (CircleCollision(spaceShip, asteroid1))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid1.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else if (CircleCollision(spaceShip, asteroid2))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid2.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else if (CircleCollision(spaceShip, asteroid3))
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                asteroidSprite = asteroid3.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.red;
                asteroidSprite.color = Color.red;
            }
            else
            {
                shipSprite = spaceShip.GetComponent<SpriteRenderer>();
                shipSprite.color = Color.white;

                asteroidSprite = asteroid1.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;

                asteroidSprite = asteroid2.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;

                asteroidSprite = asteroid3.GetComponent<SpriteRenderer>();
                asteroidSprite.color = Color.white;
            }
        }
    }

    bool AABBCollision(GameObject theShip, GameObject theAsteroid)
    {
        shipSprite = theShip.GetComponent<SpriteRenderer>();
        asteroidSprite = theAsteroid.GetComponent<SpriteRenderer>();

        if (
            (asteroidSprite.bounds.min.x < shipSprite.bounds.max.x) &&
            (asteroidSprite.bounds.max.x > shipSprite.bounds.min.x) &&
            (asteroidSprite.bounds.max.y > shipSprite.bounds.min.y) &&
            (asteroidSprite.bounds.min.y < shipSprite.bounds.max.y)
           )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CircleCollision(GameObject theShip, GameObject theAsteroid)
    {
        shipSprite = theShip.GetComponent<SpriteRenderer>();
        asteroidSprite = theAsteroid.GetComponent<SpriteRenderer>();

        float currDistance =
            Mathf.Pow((shipSprite.bounds.center.x - asteroidSprite.bounds.center.x), 2f) +
            Mathf.Pow((shipSprite.bounds.center.y - asteroidSprite.bounds.center.y), 2f);

        if (currDistance < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnClick()
    {
        if (aABBCollision)
        {
            currentCollision.text = "Circle Collision";
            aABBCollision = false;
            circleCollision = true;
        }
        else if (circleCollision)
        {
            currentCollision.text = "AABB Collision";
            aABBCollision = true;
            circleCollision = false;
        }
    }
}