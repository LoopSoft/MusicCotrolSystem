using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Garante que tudo envolvendo controle de audio está interligado.
/// </summary>
public sealed class SoundSystem: MonoBehaviour
{

    // INIT ATRIBUTOS
    private static SoundSystem _AudioConfiguration = new SoundSystem(); //Cria instanci dele mesmo.
    public static SoundSystem Instance //Propriedade para instanciar a instancia.
    {
        get { return _AudioConfiguration; }
    }
    static float volumeMusic = 1; //Volume da musica geral.
    public float VolumeMusic
    {
        get { return volumeMusic; }
        set { volumeMusic = value; }
    }
    static float volumeEffects = 1; //Volume dos efeitos gerais.
    public float VolumeEffects
    {
        get { return volumeEffects; }
        set { volumeEffects = value; }
    }
    // END ATRIBUTOS

    // INIT METODOS
    /// <summary>
    /// Pausa todas as musicas atribuidas a função.
    /// </summary>
    /// <param name="Audio"></param>
    public void Pause(List<AudioSource> Audio)
    {
        for(int i = 0; i < Audio.Count; ++i)
            Audio[i].Pause();
    }
    /// <summary>
    /// Da play em todas as musicas atribuidas a função.
    /// </summary>
    /// <param name="Audio"></param>
    public void Play(List<AudioSource> Audio)
    {
        for (int i = 0; i < Audio.Count; ++i)
            Audio[i].Play();
    }
    /// <summary>
    /// Garante a mudança de volume das musicas atribuidas a função.
    /// </summary>
    /// <param name="Audio"></param>
    /// <param name="Volume"></param>
    public void VolumeControl(List<AudioSource> Audio, float Volume)
    {
        for (int i = 0; i < Audio.Count; ++i)
            Audio[i].volume = Volume;
    }
    //EMD METODOS
    private SoundSystem() { }
    void Update()
    {
    }
}
