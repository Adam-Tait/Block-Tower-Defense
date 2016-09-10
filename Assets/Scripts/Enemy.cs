using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform path;

    public int health = 1;
    public float speed = 15f;
    private Color color;

    private int waypointIndex;

    void Start ()
    {
        path = Waypoints.waypoints[0];
    }

    void Update ()
    {
        Vector2 direction = path.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, path.position) <= 0.05f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        path = Waypoints.waypoints[waypointIndex];
    }

    void OnCollisonEnter2D (Collider coll)
    {
        if (coll.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
                Destroy(gameObject);
        }
        if (health == 16)
            color = Color.black;
        else if (health == 8)
            color = Color.yellow;
        else if (health == 4)
            color = Color.green;
        else if (health == 2)
            color = Color.blue;
        else if (health == 1)
            color = Color.red;
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
