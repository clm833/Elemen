using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Vector2 angle=new Vector2(90*Mathf.Deg2Rad,0);
    public Transform Jugador;
    public float maxdistancia;
    public Vector2 sensibilidad;
    private new Camera camera;
    private Vector2 nearPlaneSize;
    public LayerMask s;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();

        CalcNearPlaneSize();
    }

    private void CalcNearPlaneSize()
    {
        float alto = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * camera.nearClipPlane;
        float ancho = alto * camera.aspect;
        nearPlaneSize = new Vector2(ancho, alto);
    }

    private Vector3[] GetCameraColisionPoints(Vector3 direction)
    {
        Vector3 position = Jugador.position;
        Vector3 center = position + direction * (camera.nearClipPlane + 0.3f);
        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        return new Vector3[]
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up,
        };
    }
    // Update is called once per frame
    private void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensibilidad.x;
        }
        float ver = Input.GetAxis("Mouse Y");
        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensibilidad.y;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }
    }
    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );

        RaycastHit hit;
        float distancia = maxdistancia;
        Vector3[] points = GetCameraColisionPoints(direction);

        foreach(Vector3 point in points)
        {
            if (Physics.Raycast(Jugador.position, direction, out hit, maxdistancia,s))
            {
                distancia = Mathf.Min((hit.point - Jugador.position).magnitude, distancia);
            }
        }
        
        transform.position = Jugador.position + direction * distancia;
        transform.rotation = Quaternion.LookRotation(Jugador.position - transform.position);
    }
}
