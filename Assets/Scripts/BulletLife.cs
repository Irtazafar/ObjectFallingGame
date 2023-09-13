using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float life = 3f;

    private void Awake()
    {
        Destroy(gameObject,life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
