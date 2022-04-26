using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

public class Levels
{
    private TiledLoader loader;
    private List<TiledObject> tiledObjects = new List<TiledObject>();
    private string filename;

    public Levels(string filename)
    {
        this.filename = filename;

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += OnSpriteCreated;

    }

    private void OnSpriteCreated(Sprite sprite, TiledObject obj)
    {

    }

    void Update()
    {
        //stuff
    }
}




