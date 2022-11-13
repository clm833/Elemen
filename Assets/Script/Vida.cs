using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public Camara camara;
    public float hp;
    public bool dag;
    public GameObject cadaver;
    private float vidaMax;
    public bool alive = true;
    public BarraDeVida interfaz;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(dag) Restar(0.01f);
        if (hp <= 0) {
            GameObject c = Instantiate(cadaver, transform.position, transform.rotation);
            alive = false;
        }
        if (alive) interfaz.actualizar(hp.ToString());
        else
        {
            interfaz.actualizar("Fallecido");
            //anim.SetTrigger("fallecido");
            //SceneManager.LoadScene("elemen 14");
            //Destroy(gameObject);
        }
    }
    public void Restar(float hvida)
    {
        hp -= hvida;
        if(hp > vidaMax) hp = vidaMax;
        dag =true;
    }
    public void apag()
    {
        dag = false;
    }
}
