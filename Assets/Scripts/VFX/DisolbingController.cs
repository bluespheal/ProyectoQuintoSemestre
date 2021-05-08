using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DisolbingController : MonoBehaviour
{
    public Animator animator;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.2f;
    public float refreshRate;
    public float dieDelay;

    private Material[] dissolveMaterials;
    // Start is called before the first frame update
    void Start()
    {
        if(VFXGraph != null)
        {
            VFXGraph.Stop();
            VFXGraph.gameObject.SetActive(false);
        }

        if(skinnedMeshRenderer != null)
        {
            dissolveMaterials = skinnedMeshRenderer.materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dissolve());
        }*/
    }
    

    public void LamarDisolve()
    {
        StartCoroutine(Dissolve());
    }

    IEnumerator Dissolve()
    {
        if(animator != null)
        {
            animator.SetTrigger("die");
        }

        yield return new WaitForSeconds(dieDelay);

        if(VFXGraph != null)
        {
            VFXGraph.gameObject.SetActive(true);
            VFXGraph.Play();
        }
        float counter = 0;
        int IdDissolveAmount = Shader.PropertyToID("DissolveAmount_");
        if(dissolveMaterials.Length > 0)
        {
            while(dissolveMaterials[0].GetFloat(IdDissolveAmount) < 1)
            {
                counter += dissolveRate;

                for(int i = 0; i < dissolveMaterials.Length; i++)
                {
                    dissolveMaterials[i].SetFloat(IdDissolveAmount, counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
        Destroy(gameObject, 1);
    }
}
