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

        TiledLoader loader;

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

        public void loadLevel(string LevelName)
        {
            foreach (GameObject Child in GetChildren())
            {
                Child.Destroy();
            }

            switch (LevelName)
            {
                
                default:
                    Console.WriteLine($"{LevelName} is not supported");
                    break;
            }
        }
    }
}

