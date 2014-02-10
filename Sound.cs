using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
namespace SORAKAKE.Ver1
{
    class Sound
    {
       

        public Cue bgm2;
        
        bool loopPlay = true;
        // オーディオカテゴリー
        

        public void BGM(SoundBank soundBank, AudioEngine engine, Cue bgm,String str)
        {
            AudioCategory audioCategory;
            audioCategory = engine.GetCategory("Default");
            if(str.Equals("pati"))
                audioCategory.SetVolume(2f);
                //BGMキューの取得
                bgm2 = soundBank.GetCue(str);
                bgm2.Play();
        }

        public void BGM2(ref SoundBank soundBank,ref AudioEngine engine,ref Cue bgm3, String str,float volume)
        {
            AudioCategory audioCategory;
            audioCategory = engine.GetCategory("Default");
            if (volume > 1500)
                volume = 1500;
            volume =((volume- 1500)*-1)/750;
            audioCategory.SetVolume(volume);
            //bgm3.Play();
            if(bgm3.IsStopped){
                 //BGMキューの取得
                 bgm3 = soundBank.GetCue(bgm3.Name);
                 bgm3.Play();
            }
        }

        public void BGM3(ref SoundBank soundBank, ref AudioEngine engine, ref Cue bgm4, String str, float volume)
        {
            AudioCategory audioCategory;
            audioCategory = engine.GetCategory("Default");
            if (volume > 100)
                volume = 100;
            volume = volume / 50f;
            audioCategory.SetVolume(volume);
           
            if (bgm4.IsStopped)
            {
                //BGMキューの取得
                bgm4 = soundBank.GetCue(bgm4.Name);
                bgm4.Play();
            }
        }


    }
}
