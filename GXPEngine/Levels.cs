using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

public class Levels : GameObject
{
    private TiledLoader loader;
    private List<TiledObject> tiledObjects = new List<TiledObject>();
    private string filename;

    public Levels(string filename)
    {
        this.filename = filename;

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += OnSpriteCreated;
        StartLevel();

    }

    private void OnSpriteCreated(Sprite sprite, TiledObject obj)
    {

    }

    private void StartLevel(bool includeImageLayers = true)
    {
        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadImageLayers();
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();
    }

    void Update()
    {
        //stuff
    }
}




