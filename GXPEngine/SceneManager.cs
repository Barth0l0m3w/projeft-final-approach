using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    public class SceneManager : GameObject
    {
        //private int whatLevel = 0;
        private static SceneManager _instance;

        private SoundChannel mainMenuMusic = null;

        public static SceneManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SceneManager();
                }
                return _instance;
            }
        }

        public SceneManager()
        {
            if (_instance != null)
            {
                Destroy();
                return;
            }
            _instance = this;
        }

        void Update()
        {

        }

        public void LoadLevel(string LevelName)
        {
            foreach (GameObject Child in GetChildren())
            {
                Child.Destroy();
            }
            
            LevelLoader levelLoader = new LevelLoader($"{LevelName}.tmx");
            AddChild(levelLoader);
            LoadMusic(LevelName);
        }

        private void LoadMusic(string filename)
        {
            if (filename.Contains("Menu"))
            {
                StartMusic("main_menu_music_hq.wav");
            }
            else if(filename.Contains("Level"))
            {
                StartMusic("gameplay_music_hq.wav");
            }
            else
            {
                StopMusic();
            }
        }

        private void StopMusic()
        {
            if(mainMenuMusic != null)
            {
                mainMenuMusic.Stop();
            }
        }

        private void StartMusic(string trackName)
        {
            StopMusic();
            mainMenuMusic = new Sound(trackName, true, true).Play();
            mainMenuMusic.Volume = 3f;
        }
    }
}