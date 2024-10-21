using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_Enemy : MonoBehaviour
{
    public static int numPatroler;
    internal GameObject player;
    internal NavMeshAgent agent;
    internal Renderer render;
    internal Vector3 destination;
    public float patrolDistance = 5;
    public float destinationTime = 4;
    public float enemySpeed;
    private Vector3 startPos;

    void Start()
    {
        render = GetComponent<Renderer>();
        Restart._Restart.OnRestart += Reset;
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));
        startPos = this.transform.position;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PP");
    }

    private void Reset()
    {
        //Para reiniciar la posicion del Player
        this.transform.position = startPos;
    }

    //internal virtual void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Projectile"))
    //    {
    //        Destroy(collision.gameObject);
    //        Destroy(this.gameObject);
    //    }
    //    if (collision.gameObject.CompareTag("CannonBall"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    if (collision.gameObject.CompareTag("Bumeran"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnDestroy()
    {

    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
