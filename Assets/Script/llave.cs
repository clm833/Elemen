using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class llave : MonoBehaviour
{
    // Start is called before the first frame update
    public Salida contador;
    public Mostratllave mostrar;
    // Start is called before the first frame update

    void Start()
    {
      //mostrar.actuallave(contador.key.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        mostrar.actuallave(contador.key.ToString());
    }

    public void OnTriggerEnter(Collider other)
    {
        contador.key++;
        Debug.Log(contador.key);
        Debug.Log(gameObject.ToString());
        Destroy(gameObject);
        
    }

}
