using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float suavidad = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f);

    [Header("Arrastra aquí tu caja de Límites")]
    [SerializeField] private BoxCollider2D mapaLimites;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 posicionDeseada = target.position + offset;

        if (mapaLimites != null)
        {
            float altoCamara = cam.orthographicSize;
            float anchoCamara = altoCamara * cam.aspect;

            float minX = mapaLimites.bounds.min.x + anchoCamara;
            float maxX = mapaLimites.bounds.max.x - anchoCamara;
            float minY = mapaLimites.bounds.min.y + altoCamara;
            float maxY = mapaLimites.bounds.max.y - altoCamara;

            posicionDeseada.x = Mathf.Clamp(posicionDeseada.x, minX, maxX);
            posicionDeseada.y = Mathf.Clamp(posicionDeseada.y, minY, maxY);
        }

        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavidad * Time.deltaTime);
    }
}