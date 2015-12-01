using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// Apenas gerencia as alterações e envia para SoundSystem as atualizações da parte de audio.
/// 
/// OBS.: precisa de ajustes para caso o programa apenas tenha efeitos sonoros ou apenas musicas.
/// </summary>
public class MusicManager : MonoBehaviour {

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
            volumeMusica.value = test.VolumeMusic;
            volumeEfeitos.value = test.VolumeEffects;
        }
    }
	void Update ()
    {
        //Garante que só vai atualizar o volume de SoundSystem se a classe tiver atribuido as barras de volume.
        if (volumeMusica != null && volumeEfeitos != null)
        {
            test.VolumeMusic = volumeMusica.value;
            test.VolumeEffects = volumeEfeitos.value;

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
    public void OnOff() { }
    // END METODOS DA CLASSE 
}
