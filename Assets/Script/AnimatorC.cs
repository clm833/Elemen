using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorC : MonoBehaviour
{
    private Animator anim;
    private CharacterController cc;
    public new Transform camera;
    public float Velocidad;
    private float Turbo;
    private bool ac;
    private float Animacion;
    public float Mvertical;
    public float Fsalto;
    public float Gravedad;
    public int Jump; 
    public bool caer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        caer = false;
        ac = true;
        Turbo = Velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 m = Vector3.zero;
        float ms = 0;
        Mvertical += Gravedad * Time.deltaTime;
        if (cc.isGrounded)
        {
            Mvertical = 0;
            Jump = 0;
        }
        if (Mvertical < 0 & caer == false) {gameObject.layer = 2;}

        if (Mvertical < -0.6 & Jump < 1) {Jump++;}

        if (Mvertical < -5) {caer = false;}

        if (Input.GetKey(KeyCode.Z) & Input.GetKeyDown(KeyCode.Space))
        {
            caer = true;
            gameObject.layer = 7;
        }
        if (Input.GetKeyDown(KeyCode.Space) & Jump < 2 & caer == false)
        {
            Jump++;
            Mvertical = Fsalto;
            gameObject.layer = 7;
        }

        if (hor!=0 |ver!=0)
        {
            if (Input.GetKey(KeyCode.LeftShift)& ac==true)
            {
                ac = false;
                Velocidad = Velocidad+ 10;
            }
            if (!Input.GetKey(KeyCode.LeftShift) & ac == false)
            {
                ac = true;
                Velocidad = Turbo;
            }

            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direccion = forward * ver + right * hor;
            ms = Mathf.Clamp01(direccion.magnitude);
            direccion.Normalize();

            m = direccion * Velocidad * ms;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direccion), 0.2f);
            
            Animacion = Velocidad;
        }
        if (hor == 0 & ver == 0 & Animacion == Velocidad)
        {
            Animacion=0;
            
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("golpe");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetTrigger("proteger");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("fallecido");
        }
        m.y = Mvertical;
        //Debug.Log(Animacion);
        cc.Move(m*Time.deltaTime);
        anim.SetFloat("VP", Animacion);
        anim.SetFloat("Mvertical", Mvertical);

    }
}
