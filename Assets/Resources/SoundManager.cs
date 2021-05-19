using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    //Creamos un enum para darle nombres a los sonidos
    public enum Sound
    {
        alerta,
        swing,
        reflejar,
        lanzar,
        gah,
        guh,
        hit,
        destruir,
    }
    //Se declara un objeto que reproduce los sonidos y se puede reciclar
    static GameObject oneShotGameObject;
    static AudioSource oneShotAudioSource;
    //Funcion que solicita el nombre del sonido que quieres reproducir
    public static void playSound(Sound sound)
    {
        //Si es la primera vez que se pide un sonido o no hay uno pre hecho...
        if (oneShotGameObject == null)
        {
            //...Creo un objeto que pueda reproducir sonidos
            oneShotGameObject = new GameObject("Sound");
            oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }
        //Reprodusco el sonido
        oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
    }
   
    //Funcion que busca los sonidos por el nombre que se les asigne
    private static AudioClip GetAudioClip(Sound sound)
    {
        //Busca en el array de sonidos el que corresponda su nombre
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            //Si lo encuentro lo regreso
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        //Si no lo encuentro envio un mensaje de error.
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
