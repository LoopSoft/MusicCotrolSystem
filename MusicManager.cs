using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// Apenas gerencia as alterações e envia para SoundSystem as atualizações da parte de audio.
/// 
/// OBS.: precisa de ajustes para caso o programa apenas tenha efeitos sonoros ou apenas musicas.
/// </summary>
public class MusicManager : MonoBehaviour
{

    SoundSystem test = SoundSystem.Instance;

    // INIT DECLARAÇÕES DE AUDIO.
    public List<AudioSource> musica;
    public List<AudioSource> efeitos;

    public Scrollbar volumeMusica;
    public Scrollbar volumeEfeitos;
    // END DECLARAÇÕES DE AUDIO.

    void Start()
    {
        //Garante que o Valor inicial sempre vai ser o de SoundSystem caso as barras sejam declaradas.
        if (volumeMusica != null && volumeEfeitos != null)
        {
            test.init();// INICIALIZA A FUNÇÃO ATRIBUINDO OS VALORES GUARDADOS NO PLAYER PREF

            volumeMusica.value = test.VolumeMusic;
            volumeEfeitos.value = test.VolumeEffects;
        }
    }
    void Update()
    {
        //Garante que só vai atualizar o volume de SoundSystem se a classe tiver atribuido as barras de volume.
        if (volumeMusica != null && volumeEfeitos != null)
        {
            test.VolumeMusic = volumeMusica.value;
            test.VolumeEffects = volumeEfeitos.value;

            test.StoresNewVolume(volumeMusica.value, volumeEfeitos.value);

            test.VolumeControl(musica, test.VolumeMusic);
            test.VolumeControl(efeitos, test.VolumeEffects);
    
    }
        //Caso não seja declarado as barras de volume ele apenas ganrante que o volume é o mesmo em qualquer canto.
        else
        {
            test.VolumeControl(musica, test.VolumeMusic);
            test.VolumeControl(efeitos, test.VolumeEffects);
        }
    }
    // INIT METODOS DA CLASSE
    bool flag_OnOffMusic = true;
    bool flag_OnOffEffects = true;
    bool flag_OnOffMusicEffects = true;
    /// <summary>
    /// Desliga a musica ou liga 
    /// </summary>
    public void OnOffMusic()
    {
        if(flag_OnOffMusic)
        {
            flag_OnOffMusic = false;
            test.Pause(musica);
        }
        else
        {
            flag_OnOffMusic = true;
            test.Play(musica);
        }
    }
    /// <summary>
    /// Desliga o efeitos do jogo ou liga
    /// </summary>
    public void OnOffEffects()
    {
        if (flag_OnOffEffects)
        {
            flag_OnOffEffects = false;
            test.Pause(efeitos);
        }
        else
        {
            flag_OnOffEffects = true;
            test.Play(efeitos);
        }
    }
    /// <summary>
    /// Desliga ou liga a musica e os efeitos do jogo
    /// </summary>
    public void OnOffMusicEffects()
    {
        if (flag_OnOffMusicEffects)
        {
            flag_OnOffMusicEffects = true;
            test.Pause(efeitos);
            test.Pause(musica);
        }
        else
        {
            flag_OnOffMusicEffects = false;
            test.Play(efeitos);
            test.Play(musica);
        }
    }
    // END METODOS DA CLASSE 
}
