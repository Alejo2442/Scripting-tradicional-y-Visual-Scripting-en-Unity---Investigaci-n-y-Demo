using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Configuraci�n")]
    public float velocidad = 2f;
    public string tagManzana = "Manzana";
    public string tagRebote = "Rebote"; // El tag de las paredes invisibles

    private Rigidbody2D rb;
    private Collider2D miCollider;
    private bool moviendoIzquierda = true; // El gusano empieza yendo a la izquierda

    void Start()
    {
        // Tomamos el componente f�sico del gusano
        rb = GetComponent<Rigidbody2D>();
        miCollider = GetComponent<Collider2D>();

        IgnorarManzanas();
    }

    void Update()
    {
        // Empujamos al gusano constantemente usando el motor f�sico real
        // Mantenemos la gravedad natural (rb.velocity.y) intacta
        if (moviendoIzquierda)
        {
            rb.linearVelocity = new Vector2(-velocidad, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
        }
    }

    // Esta funci�n detecta cuando el gusano toca la pared invisible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagRebote))
        {
            // Invertimos la direcci�n y volteamos el sprite
            moviendoIzquierda = !moviendoIzquierda;
            Voltear(moviendoIzquierda);
        }
    }

    void Voltear(bool mirarIzq)
    {
        Vector3 escala = transform.localScale;
        escala.x = mirarIzq ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
        transform.localScale = escala;
    }

    void IgnorarManzanas()
    {
        GameObject[] manzanas = GameObject.FindGameObjectsWithTag(tagManzana);
        foreach (GameObject manzana in manzanas)
        {
            Collider2D manzanaCollider = manzana.GetComponent<Collider2D>();
            if (manzanaCollider != null && miCollider != null)
            {
                Physics2D.IgnoreCollision(miCollider, manzanaCollider);
            }
        }
    }
}