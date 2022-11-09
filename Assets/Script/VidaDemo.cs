using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaDemo : MonoBehaviour
{
    public float vida;
    private float vidaMax;
    public bool alive = true;
    public MostrarVida intefaz;
    public bool burning;
    private Animator anim;
    private scrip muerte;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        vidaMax = vida;
        intefaz.actualizar(vida.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (burning) HoD(-0.1f);
        muerte = GetComponent<scrip>();
    }

    public void HoD(float amount)
    {
        vida += amount;
        if (vida > vidaMax) vida = vidaMax;
        if (vida < 0) alive = false;
        if (alive) intefaz.actualizar(vida.ToString());
        else 
        {
            intefaz.actualizar("Fallecido"); 
            anim.SetTrigger("Fallece");
            muerte.parar();
            ///Destroy(gameObject);
        }
    }
}