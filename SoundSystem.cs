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
    static float volumeMusic; //Volume da musica geral.
    public float VolumeMusic
    {
        get { return volumeMusic; }
        set { volumeMusic = value; }
    }
    static float volumeEffects; //Volume dos efeitos gerais.
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
    /// <summary>
    /// Armazena a configuração para a proxima vez que o usuario entrar no jogo.
    /// </summary>
    /// <param name="valueMusic"></param>
    /// <param name="valueEffects"></param>
    public void StoresNewVolume(float valueMusic, float valueEffects)
    {
        PlayerPrefs.SetFloat("Music", valueMusic);
        PlayerPrefs.SetFloat("Effects", valueEffects);
    }
    //EMD METODOS
    private SoundSystem() { }
    //bool cont = true;
    public void init()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            VolumeMusic = PlayerPrefs.GetFloat("Music");
            VolumeEffects = PlayerPrefs.GetFloat("Effects");
            print("1");
        }
        else
        {
            VolumeEffects = 1;
            VolumeMusic = 1;
            print("2");
        }
    }
}
