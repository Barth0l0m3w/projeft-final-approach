﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


public class VisualSpellRange : Sprite
{

    public VisualSpellRange(TiledObject obj = null) : base("spell range bubble.png", false)
    {
        SetOrigin(width/2, height/2);
    }
}

