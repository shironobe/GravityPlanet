using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

   public bool ShouldRespawn;


    public AudioSource[] MusicList;

    public AudioSource[] Sfx;

    public bool muted, mutedSfx;

    public Image Audio, Music;
    public Sprite On, Off;
    public Sprite MusicOn, MusicOff;
    private void Awake()
    {
        if (Instance != null)
        {
             Destroy(gameObject);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

        }
    }
    void Start()
    {
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PlaySfx(int Sfxno)
    {
        Sfx[Sfxno].Stop();
       // Sfx[Sfxno].volume = 0;
        Sfx[Sfxno].Play();
    }


    public void KeepPlayingSfx(int no)
    {
        if (!Sfx[no].isPlaying)
        {
            Sfx[no].Play();
        }
    }

    public void StopSound(int no)
    {
        Sfx[no].Stop();
    }
    public void PlayMusic(int MusicNo)
    {
        for (int i = 0; i < MusicList.Length; i++)
        {
            MusicList[i].Stop();
        }

        MusicList[MusicNo].Play();
    }

    public void StopMusic()
    {
        if (!muted)
        {
            for (int i = 0; i < MusicList.Length; i++)
            {
                MusicList[i].volume = 0;
            }
            muted = true;
         
        }
        else
        {
            for (int i = 0; i < MusicList.Length; i++)
            {
                MusicList[i].volume = 0.7f;
            }
            
            muted = false;
          

        }
        updateMusicIcon();
    }

    public void StopSFX()
    {
        if (!mutedSfx)
        {

            for (int i = 1; i < Sfx.Length; i++)
            {
                Sfx[i].volume = 0;
            }
          
            //Sfx[6].volume = 0;
            //Sfx[7].volume = 0;
            //Sfx[8].volume = 0;
            //Sfx[9].volume = 0;
            mutedSfx = true;
        }
        else
        {
            for (int i = 1; i < Sfx.Length; i++)
            {
                Sfx[i].volume = 1;
            }
           
            //Sfx[6].volume = 0.17f;
            //Sfx[7].volume = 0.17f;
            //Sfx[8].volume = 0.17f;
            //Sfx[9].volume = 0.17f;
            mutedSfx = false;
           PlaySfx(1);

        }
        updateIcon();
    }
    //public void SoundOnOff()
    //{

    //    if (!muted)
    //    {
    //        muted = true;
    //        AudioListener.pause = true;
    //    }
    //    else
    //    {
    //        if (muted)
    //        {
    //            AudioManager.instance.PlaySfx(5);
    //            muted = false;
    //            AudioListener.pause = false;
    //        }
    //    }
    //    //save();
    //    updateIcon();
    //}
    private void updateIcon()
    {
        if (!mutedSfx)
        {
            Audio.sprite = On;

        }
        else
        {
            if (mutedSfx)
            {
                Audio.sprite = Off;
            }

        }
    }
    private void updateMusicIcon()
    {
        if (!muted)
        {
            Music.sprite = MusicOn;

        }
        else
        {
            if (muted)
            {
                Music.sprite = MusicOff;
            }

        }
    }
}
