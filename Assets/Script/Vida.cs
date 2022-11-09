using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public float vida;
    private float vidaMax;
    public bool alive = true;
    public MostrarVida intefaz;
    public bool burning;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        vidaMax = vida;
        intefaz.actualizar(vida.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (burning) HoD(-0.1f);
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
            //anim.SetTrigger("fallecido");
            //SceneManager.LoadScene("elemen 14");
            Destroy(gameObject);
        }
    }
}