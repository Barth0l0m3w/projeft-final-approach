using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    public class SceneManager : GameObject
    {
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
            
            //making the name put in the correct file so the scenemanager can load it from tiled when activated
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
                mainMenuMusic.Volume = 1f;
            }

            else
            {
                StopMusic();
            }
        }

        private void StopMusic()
        {
            //stopping the music
            if(mainMenuMusic != null)
            {
                mainMenuMusic.Stop();
            }
        }

        private void StartMusic(string trackName)
        {
            //stopping the previous music and starting the new correct one
            StopMusic();

            //adding a string in the construct to start a custom soundtrack for every scene you want
            mainMenuMusic = new Sound(trackName, true, true).Play();
            mainMenuMusic.Volume = 2f;
        }
    }
}