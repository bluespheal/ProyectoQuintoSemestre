using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaDesaparecer : MonoBehaviour
{
    public float dissolveRate = 0.2f;
    public float refreshRate;
    public float dieDelay;

    public Material[] dissolveMaterials;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dissolve());
    }

    IEnumerator Dissolve()
    {
        int IdDissolveAmount = Shader.PropertyToID("DissolveAmount_");
        dissolveMaterials[0].SetFloat(IdDissolveAmount, 0);
        dissolveMaterials[1].SetFloat(IdDissolveAmount, 0);
        yield return new WaitForSeconds(dieDelay);

        float counter = 0;
        
        if (dissolveMaterials.Length > 0)
        {
            WaitForSeconds rr = new WaitForSeconds(refreshRate);
            while (dissolveMaterials[0].GetFloat(IdDissolveAmount) < 1)
            {
                counter += dissolveRate;

                for (int i = 0; i < dissolveMaterials.Length; i++)
                {
                    dissolveMaterials[i].SetFloat(IdDissolveAmount, counter);
                }
                yield return rr;
            }
        }

        Destroy(gameObject, 1);
    }
}
