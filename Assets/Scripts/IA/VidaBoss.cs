using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    public int vidaMax;
    WaitForSeconds tiempo;
    TorretaIA ia;
    public GameObject ps1;
    public GameObject ps2;
    public GameObject ps3;
    public GameObject ps4;
    public GameObject psh;
    public SceneChanger sc;
    public GameObject cuerpo;
    Vector3 origen = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        vidaMax = 10;
        tiempo = new WaitForSeconds(0.7f);
        ia = GetComponent<TorretaIA>();
        //StartCoroutine(Muerte());
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balaReflejada") || other.gameObject.CompareTag("bateAzul") || other.gameObject.CompareTag("bateRojo"))
        {
            if (transform.position != origen)
                transform.position = origen;
            psh.SetActive(true);
            disminuirVida();
        }
    }



    void disminuirVida()
    {
        vidaMax--;
        if(vidaMax <= 0)
        {
            StartCoroutine(Muerte());
        }
    }

    

    IEnumerator Muerte()
    {
        yield return new WaitForSeconds(2);
        ia.enabled = false;
        ps1.SetActive(true);
        yield return tiempo;
        ps2.SetActive(true);
        yield return tiempo;
        ps3.SetActive(true);
        yield return tiempo;
        cuerpo.SetActive(false);
        ps1.SetActive(false);
        ps2.SetActive(false);
        ps3.SetActive(false);
        ps4.SetActive(true);
        yield return tiempo;
        yield return tiempo;
        sc.ChangeLevel("Menu");
    }
}
