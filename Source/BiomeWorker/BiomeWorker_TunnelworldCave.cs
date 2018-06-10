﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace TerraFW
{

    public class BiomeWorker_TunnelworldCave : BiomeWorker
    {

        public override float GetScore(Tile tile)
        {
            if (tile.hilliness == Hilliness.Flat)
            {
                return -100f;
            }
            if (tile.WaterCovered || Rand.Value > 0.0030f)
            {
                return -100f;
            }
            if (tile.temperature < -15f)
            {
                return 0f;
            }
            return 40f;
        }

    }

}