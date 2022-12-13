using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum typeSound
{
    bg, gasha, reword
}
public class soundControl :  MonoBehaviour
{
    // public static soundControl _soundControl;
    public AudioClip bgSound, ramdownSound,rewordSound,hitSound,lightSound;
    public AudioClip[] effect;
    public static AudioSource _bgSound, _ramdownSound, _rewordSound, _hitSound, _lightSound;
    public static AudioSource[] _effect ;
    //public int b;
    // Start is called before the first frame update
    void Start()
    {
         _effect = new AudioSource[effect.Length];

        _bgSound = gameObject.AddComponent<AudioSource>();
         _bgSound.clip = bgSound;
         _bgSound.volume = 0.5f;
         _bgSound.playOnAwake = false;
         _bgSound.loop = true;
      
      /*  _ramdownSound = gameObject.AddComponent<AudioSource>();
        _ramdownSound.clip = ramdownSound;
        _ramdownSound.volume = 1.0f;
        _ramdownSound.playOnAwake = false;
        _ramdownSound.loop = false;

        _rewordSound = gameObject.AddComponent<AudioSource>();
        _rewordSound.clip = rewordSound;
        _rewordSound.volume = 1.0f;
        _rewordSound.playOnAwake = false;
        _rewordSound.loop = false;


        _hitSound = gameObject.AddComponent<AudioSource>();
        _hitSound.clip = hitSound;
        _hitSound.volume = 1.0f;
        _hitSound.playOnAwake = false;
        _hitSound.loop = false;

        _lightSound = gameObject.AddComponent<AudioSource>();
        _lightSound.clip = lightSound;
        _lightSound.volume = 1.0f;
        _lightSound.playOnAwake = false;
        _lightSound.loop = false;*/
        for (int i = 0; i < effect.Length; i++)
        {
            _effect[i] = gameObject.AddComponent<AudioSource>();
            _effect[i].clip = effect[i];
            _effect[i].volume = 1.0f;
            _effect[i].playOnAwake = false;
            if(i == 9)
            {
                _effect[i].loop = true;
            }
            else
            {
                _effect[i].loop = false;
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound(string type)
    {
       
        switch (type)
        {
            case "bg":

               _bgSound.Play();
                break;
            case "gasha":
                _ramdownSound.Play();
                break;
            case "reward":
                //Debug.Log("reward");
                _rewordSound.Play();
                break;
            case "hit":  
               _hitSound.Play();
                break;
            case "light":
                _lightSound.Play();
                break;
            case "eff1":
                _effect[0].Play();
                break;
            case "eff2":
                _effect[1].Play();
                break;
            case "eff3":
                _effect[2].Play();
                break;
            case "eff4":
                _effect[3].Play();
                break;
            case "eff5":
                _effect[4].Play();
                break;
            case "eff6":
                _effect[5].Play();
                break;
            case "eff7":
                _effect[6].Play();
                break;
            case "eff8":
                _effect[7].Play();
                break;
            case "eff9":
                _effect[8].Play();
                break;
            case "eff10":
                Debug.Log(" play 10-=---");
                _effect[9].Play();
                break;
            case "eff11":
                _effect[10].Play();
                break;
            case "eff12":
                _effect[11].Play();
                break;

        }
     }
    public static void stopSound(string type)
    {
        switch (type)
        {
            case "bg":
                _bgSound.Stop();
                break;
            case "gasha":
                _ramdownSound.Stop();
                break;
            case "reward":
                //Debug.Log("reward");
                _rewordSound.Stop();
                break;
            case "hit":
              _hitSound.Stop();
               break;
            case "eff1":
                _effect[0].Stop();
                break;
            case "eff2":
                _effect[1].Stop();
                break;
            case "eff3":
                _effect[2].Stop();
                break;
            case "eff4":
                _effect[3].Stop();
                break;
            case "eff5":
                _effect[4].Stop();
                break;
            case "eff6":
                _effect[5].Stop();
                break;
            case "eff7":
                _effect[6].Stop();
                break;
            case "eff8":
                _effect[7].Stop();
                break;
            case "eff9":
                _effect[8].Stop();
                break;
            case "eff10":
                Debug.Log(" eff 10-=---");
                _effect[9].Stop();
                break;
            case "eff11":
                _effect[10].Stop();
                break;
            case "eff12":
                _effect[11].Stop();
                break;

        }
    }
    public  void playSoundloop()
    {
        _effect[1].Play();
        StartCoroutine(waitAudio());
    }
    public  IEnumerator  waitAudio()
    {
        yield return new WaitForSeconds(_effect[1].clip.length-0.1f);
        _effect[9].Play();
    }
    public static void stopSoundAll()
    {
         _bgSound.Stop();
         _ramdownSound.Stop();
         _bgSound.Stop();
         _hitSound.Stop();
    }
}
