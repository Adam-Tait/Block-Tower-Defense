using UnityEngine;
using System.Collections;

public class enemyEnd : MonoBehaviour {

    private GameManager gameManager;

    void Awake ()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter3D (Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            gameManager.health -= 1;
        }
    }
}
