using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //todo lo pertinente a sonidos y sus metodos
    //por diego katabian

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

    [HideInInspector]
    public Dictionary<string, AudioSource> sound = new Dictionary<string, AudioSource>();

    string thisLevelBgm;

    Dictionary<string, string> levelBGMs = new Dictionary<string, string>();
    [SerializeField]
    string[] levelNames;
    [SerializeField]
    string[] bgmNames;

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
            s = s.Substring(0, s.Length - 26); //formateo para que no me quede (UnityEngine.AudioSource) en cada nombre
            sound.Add(s, _allSounds[i]);
            //print("agregue el key " + s + " con value " + allSounds[i]+ " al diccionario");
        }


        for (int i = 0; i < levelNames.Length; i++) //lleno el dictionary con los bgm
        {
            levelBGMs.Add(levelNames[i], bgmNames[i]);
        }

        //levelBGMs.Add("MainMenu", "4S_IntroBigChords");
        //levelBGMs.Add("SampleScene", "4S_MarimbaLoop");

        SceneManager.sceneLoaded += StartLevelBGM;
    }

    public void StartLevelBGM(Scene scene, LoadSceneMode lsm)
    {
        //print(scene.name);
        if (thisLevelBgm != null)
        {
            StopBGM();
        }

        thisLevelBgm = levelBGMs[scene.name];
        PlayBGM();
        //PlayByName(thisLevelBgm);
    }

    public void PlayByName(string clipName) //el mas groso. le das el string y te da play a ese audio. muy global y sencillo.
    {
        AudioSource sound;
        sound = this.sound[clipName];
        sound.Play();
    }
    public void PlayByName(string clipName, float pitch) //ahora con cambio de pitch.
    {
        AudioSource sound;
        sound = this.sound[clipName]; //establezco que voy a estar laburando con el audio cuyo nombre es clipname
        float originalPitch = sound.pitch; //pido el pitch original y lo guardo
        sound.pitch = pitch; //cambio al pitch deseado
        sound.Play(); //doy play
        StartCoroutine(SetPitchToOriginal(sound, originalPitch)); //le vuelvo a poner el pitch que tenia antes
    }

    public void PlayByNameRandomPitch(string clipName, float centralPitch, float pitchVariation) //ahora con variacion random de pitch.
    {
        AudioSource sound;
        sound = this.sound[clipName];
        float originalPitch = sound.pitch; 
        sound.pitch = Random.Range(centralPitch - pitchVariation, centralPitch + pitchVariation); //pitch +/- variacion
        sound.Play();
        StartCoroutine(SetPitchToOriginal(sound, originalPitch));
    }

    public void PlayRandom(params string[] clipNames)
    {
        int randomNumber = Random.Range(0, clipNames.Length);
        PlayByName(clipNames[randomNumber]);
    }
    public void StopByName(string clipName)
    {
        AudioSource sound;
        sound = this.sound[clipName];
        sound.Stop();
    }
    public void StopByName(params string[] clipNames)
    {
        for (int i = 0; i < clipNames.Length; i++)
        {
            AudioSource sound;
            sound = this.sound[clipNames[i]];
            sound.Stop();
        }
    }

    public void PlayOnEnd(string soundToEndName, string soundToPlayName)
    {
        AudioSource soundToEnd;
        soundToEnd = this.sound[soundToEndName];

        AudioSource soundToPlay;
        soundToPlay = this.sound[soundToPlayName];
        StartCoroutine(PlayOnOtherSoundEnd(soundToEnd, soundToPlay));
    }
    public IEnumerator SetPitchToOriginal(AudioSource sound, float originalPitch)
    {
        while (sound.isPlaying)
        {
            yield return null;
        }

        sound.pitch = originalPitch; 
    }
    public IEnumerator PlayOnOtherSoundEnd(AudioSource soundToEnd, AudioSource soundToPlay)
    {
        soundToEnd.loop = false;

        while (soundToEnd.isPlaying)
        {
            yield return null;
        }

        soundToEnd.Stop();
        soundToEnd.loop = true;

        soundToPlay.Play();
    }
    public void PlayBGM()
    {
        //print("reproduje el sonido " + thisLevelBgm);
        sound[thisLevelBgm].Play();
    }
    public void StopBGM()
    {
        sound[thisLevelBgm].Stop();
    }
    public void FadeInBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        sound[thisLevelBgm].volume = Mathf.Lerp(0, 1, timer);
    }
    public void FadeOutBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        sound[thisLevelBgm].volume = Mathf.Lerp(1, 0, timer);
    }
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
}
