using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    //Se crea una referencia para el mismo
    private static GameAssets _i;
    //Se hace un getter a la referencia para que se pueda acceder facilmente desde otros scripts 
    public static GameAssets i
    {
        get
        {
            //Debug.Log(Resources.Load<GameAssets>("GameAssets"));
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }
    //Se define un array sin expansible para almacenar sonidos con su nombre
    public SoundAudioClip[] soundAudioClipArray;
    //Se define una clase que reciba un sonido y su nombre para que se manden llamar facilmente
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
