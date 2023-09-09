using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoM : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Transform jugador;
    bool estarAlerta;
    public float velocidad; 

    private bool move=false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if(estarAlerta == true){
            //transform.LookAt(jugador);
            move=true;
            Vector3 posJugador = new Vector3(jugador.position.x,transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }else{
            move=false;
        }

        animator.SetBool("Mover",move);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }  
}
