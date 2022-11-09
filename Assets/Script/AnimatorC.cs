using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorC : MonoBehaviour
{
    private Animator anim;
    private CharacterController cc;
    public float Velocidad;
    private float Animacion;
    public float Mvertical;
    public float Fsalto;
    public float Gravedad;
    public int Jump;
    private bool correr;
    private float turbo;
    public bool caer;
    public GameObject Bala;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        caer = false;
        correr = true;
        turbo = Velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Animacion", Animacion);
        anim.SetFloat("Mvertical", Mvertical);
        Mvertical -= Gravedad * Time.deltaTime;
        if (cc.isGrounded)
        {
            Mvertical = 0;
            Jump = 0;
        }
        if (Mvertical < 0 & caer == false)
        {
            gameObject.layer = 0;
        }
        if (Mvertical < -0.6 & Jump < 1)
        {
            Jump++;
        }
        if (Mvertical < -5)
        {
            caer = false;
        }
        if (Input.GetKey(KeyCode.Z) & Input.GetKeyDown(KeyCode.Space))
        {
            caer = true;
            gameObject.layer = 7;
        }
        if (Input.GetKeyDown(KeyCode.Space) & Jump < 2 & caer == false)
        {
            //anim.SetTrigger("Jump");
            Jump++;
            Mvertical = Fsalto;
            gameObject.layer = 7;
        }
        if (Input.GetAxis("Horizontal")!=0 |Input.GetAxis("Vertical")!=0)
        {
            
            //anim.SetTrigger("walk");

            if (Input.GetKey(KeyCode.LeftShift) & correr==true)
            {
                correr = false;
                Velocidad = Velocidad + 5;
                Debug.Log("correr");
                //anim.SetTrigger("Run");
            }
            if (!Input.GetKey(KeyCode.LeftShift) & correr == false)
            {
                correr = true;
                Velocidad = turbo;
                Debug.Log("correr");
                //anim.SetTrigger("Run");
            }

            Animacion = Velocidad;
        }
        if (Input.GetAxis("Horizontal") == 0 & Input.GetAxis("Vertical") == 0 & Animacion == Velocidad)
        {
            Animacion=0;
         //   anim.SetTrigger("Run");
        }
        if(Input.GetAxis("Fire2")!=0)
        {
            Debug.Log("Achazo");
            anim.SetTrigger("golpe");
        }

        if (Input.GetAxis("Fire1")!=0)
        {
            Debug.Log("protege");
            anim.SetTrigger("proteger");
            Invoke("Disparar", 1);
        }

        Vector3 H = Input.GetAxis("Horizontal") * Velocidad * transform.right;
        H.y = Mvertical;
        Vector3 V = Input.GetAxis("Vertical") * Velocidad * transform.forward;
        V = V + H;
        cc.Move(V * Time.deltaTime);

    }

    private void Disparar()
    {
        Instantiate(Bala, transform.position, transform.rotation);
    }
}
