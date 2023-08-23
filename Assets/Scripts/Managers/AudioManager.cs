using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //todo lo pertinente a sonidos y sus metodos
    //por diego katabian


    //todo el chistecito del bgm no va. pero otro dia lo saco. hoy no.

    public static AudioManager instance;
    bool _soundOn = true;

    public bool SoundOn
    {
        get
        {
            return _soundOn;
        }
        set
        {
            _soundOn = value;
            if (_soundOn)
            {
                UnmuteAll();
            }
            else
            {
                MuteAll();
            }
        }
    }

    AudioSource[] _allSounds;
    Dictionary<KeyValuePair<string, AudioSource>, float> originalVolumes = new Dictionary<KeyValuePair<string, AudioSource>, float>();

    [HideInInspector] public Dictionary<string, AudioSource> soundDict = new Dictionary<string, AudioSource>();



    string thisLevelBgm;
    Dictionary<string, string> levelBGMs = new Dictionary<string, string>();
    [SerializeField] string[] levelNames;
    [SerializeField] string[] bgmNames;

    float globalVolume = 1;

    void Awake()
    {
        if (instance) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

        _allSounds = GetComponentsInChildren<AudioSource>(); //construyo mi array con todos los audiosource

        for (int i = 0; i < _allSounds.Length; i++) //lleno el diccionario de pares string-audiosource
        {
            string s = _allSounds[i].ToString(); //convierto a string
            s = s.Substring(0, s.Length - 26); //formateo para borrar el "UnityEngine.AudioSource" de cada nombre
            soundDict.Add(s, _allSounds[i]);
            //print("agregue el key " + s + " con value " + allSounds[i]+ " al diccionario");

            originalVolumes[new KeyValuePair<string, AudioSource>(s, _allSounds[i])] = _allSounds[i].volume;
        }

        for (int i = 0; i < levelNames.Length; i++) //lleno el dictionary con los bgm
        {
            levelBGMs.Add(levelNames[i], bgmNames[i]);
        }

        SceneManager.sceneLoaded += StartLevelBGM;
    }

    public void PlayByName(string clipName) //el mas groso. le das el string y te da play a ese audio. muy global y sencillo.
    {
        AudioSource sound;
        sound = this.soundDict[clipName];

        //float originalVolume = sound.volume;
        //sound.volume *= globalVolume;

        sound.Play();


        //StartCoroutine(SetVolumeToOriginal(sound, originalVolume));

    }
    public void PlayByName(string clipName, float pitch) //ahora con cambio de pitch.
    {
        AudioSource sound;
        sound = this.soundDict[clipName]; //establezco que voy a estar laburando con el audio cuyo nombre es clipname
        
        //float originalVolume = sound.volume;
        //sound.volume *= globalVolume;
        float originalPitch = sound.pitch; //pido el pitch original y lo guardo
        sound.pitch = pitch; //cambio al pitch deseado
        
        sound.Play(); //doy play

        //StartCoroutine(SetVolumeToOriginal(sound, originalVolume));
        StartCoroutine(SetPitchToOriginal(sound, originalPitch)); //le vuelvo a poner el pitch que tenia antes
    }
    public void PlayByName(string clipName, float centralPitch, float pitchVariation) //ahora con variacion random de pitch.
    {
        AudioSource sound;
        sound = this.soundDict[clipName];

        //float originalVolume = sound.volume;
        //sound.volume *= globalVolume;
        float originalPitch = sound.pitch; 
        sound.pitch = Random.Range(centralPitch - pitchVariation, centralPitch + pitchVariation);
        
        sound.Play();

        //StartCoroutine(SetVolumeToOriginal(sound, originalVolume));
        StartCoroutine(SetPitchToOriginal(sound, originalPitch));
    }
    public void PlayRandom(params string[] clipNames)
    {
        int randomNumber = Random.Range(0, clipNames.Length);
        PlayByName(clipNames[randomNumber]);
    }//elige al azar entre varios sonidos
    public void StopByName(string clipName)
    {
        AudioSource sound;
        sound = this.soundDict[clipName];
        sound.Stop();
    }//pone stop a un sonido
    public void StopByName(params string[] clipNames)
    {
        for (int i = 0; i < clipNames.Length; i++)
        {
            AudioSource sound;
            sound = this.soundDict[clipNames[i]];
            sound.Stop();
        }
    } //lo mismo pero a muchos
    public void PlayOnEnd(string soundToEndName, string soundToPlayName)
    {
        StartCoroutine(PlayOnOtherSoundEnd(soundToEndName, soundToPlayName));
    } //termina uno y luego pone play al otro

    //Corrutinas Auxiliares
    public IEnumerator PlayOnOtherSoundEnd(string soundToEndName, string soundToPlayName)
    {
        AudioSource soundToEnd = this.soundDict[soundToEndName];

        soundToEnd.loop = false;

        while (soundToEnd.isPlaying)
        {
            yield return null;
        }

        StopByName(soundToEndName);
        soundToEnd.loop = true;

        PlayByName(soundToPlayName);
    }
    public IEnumerator SetPitchToOriginal(AudioSource sound, float originalPitch)
    {
        while (sound.isPlaying)
        {
            yield return null;
        }

        sound.pitch = originalPitch; 
    }
    public IEnumerator SetVolumeToOriginal(AudioSource sound, float originalVolume)
    {
        while (sound.isPlaying)
        {
            yield return null;
        }

        sound.volume = originalVolume;
    }

    //Metodos de BGM
    public void StartLevelBGM(Scene scene, LoadSceneMode lsm)
    {
        //print(scene.name);
        if (thisLevelBgm != null)
        {
            StopBGM();

            if (soundDict["IntroStoryboardLoop"].isPlaying)
            {
                StopByName("IntroStoryboardLoop");
            }
        }

        thisLevelBgm = levelBGMs[scene.name];
        PlayBGM();
        //PlayByName(thisLevelBgm);
    } //si cargas bien los nombres, esto se encarga de poner play al bgm correcto en cada escena
    public void PlayBGM()
    {
        //print("reproduje el sonido " + thisLevelBgm);
        soundDict[thisLevelBgm].Play();
    }
    public void StopBGM()
    {
        soundDict[thisLevelBgm].Stop();
    }
    public void FadeInBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        soundDict[thisLevelBgm].volume = Mathf.Lerp(0, 1, timer);
    }
    public void FadeOutBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        soundDict[thisLevelBgm].volume = Mathf.Lerp(1, 0, timer);
    }

    //Metodos de Settings
    public void StopAll()
    {
        for (int i = 0; i < _allSounds.Length; i++)
        {
            _allSounds[i].Stop();
        }
    }
    public void MuteAll()
    {
        for (int i = 0; i < _allSounds.Length; i++)
        {
            _allSounds[i].mute = true;
        }
    }
    public void UnmuteAll()
    {
        for (int i = 0; i < _allSounds.Length; i++)
        {
            _allSounds[i].mute = false;
        }
    }

    public void SetGlobalVolume(float volume)
    {
        globalVolume = volume;

        foreach (KeyValuePair<KeyValuePair<string, AudioSource>, float> kvp in originalVolumes)
        {
            AudioSource sound = kvp.Key.Value;
            float originalVolume = kvp.Value;

            sound.volume = originalVolume * globalVolume;
        }
    }
}
