using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public Camera cam;
    private Rigidbody rb;
    private Renderer render;
    public static Controller_Player _Player;
    private Vector3 movement;
    private Vector3 mousePos;
    internal Vector3 shootAngle;
    private Vector3 startPos;
    private bool started = false;
    public float speed = 5;

    private void Start()
    {
        if (_Player == null)
        {
            _Player = this.gameObject.GetComponent<Controller_Player>();
        }
        startPos = this.transform.position;
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        Restart._Restart.OnRestart += Reset;
        started = true;
    }

    private void OnEnable()
    {
        if (started)
            Restart._Restart.OnRestart += Reset;
    }

    private void Reset()
    {
        //Para reiniciar la posicion del Player
        this.transform.position = startPos;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
    }

    public virtual void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public Vector3 GetLastAngle()
    {   
        //Obtencion del ultimo angulo en el que se movio el jugador
        if (Input.GetKey(KeyCode.W))
        {
            shootAngle = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            shootAngle = Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shootAngle = Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            shootAngle = Vector3.right;
        }
        return shootAngle;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }

}
