﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;

namespace TerraFW
{

    public class BiomeWorkerSpecial_InfestedMountains : BiomeWorkerSpecial
    {

        private static readonly IntRange biomeChangeDigLenth = new IntRange(3, 14);

        protected override float InitialGenChance
        {
            get { return 0.06f; }
        }

        protected override float GenChanceOffsetAfterFirstHit
        {
            get { return 0.045f; }
        }

        protected override float GenChancePerHitFactor
        {
            get { return 0.6f; }
        }

        public override bool PreRequirements(Tile tile)
        {
            if (tile.WaterCovered)
            {
                return false;
            }
            if (tile.hilliness == Hilliness.Flat)
            {
                return false;
            }
            if (tile.temperature < -10f || tile.temperature > 35f)
            {
                return false;
            }
            if (tile.rainfall < 600f)
            {
                return false;
            }
            return true;
        }

        public override void PostGeneration(int tileID)
        {
            int digLength = biomeChangeDigLenth.RandomInRange;
            DigTilesForBiomeChange(tileID, digLength, 2);
        }

        protected override void ChangeTileAfterSuccessfulDig(Tile tile, bool end)
        {
            tile.biome = BiomeDefOf.InfestedMountains;
            GenWorldGen.UpdateTileByBiomeModExts(tile);
        }

        public override WLTileGraphicData GetWLTileGraphicData(WorldGrid grid, int tileID)
        {
            int atlasX;
            int atlasZ;
            Vector3 rotVector;
            grid.GetTileGraphicDataFromNeighbors(tileID, out atlasX, out atlasZ, out rotVector, (Tile tileFrom, Tile neighbor) => (tileFrom.biome == neighbor.biome));
            return new WLTileGraphicData(WorldMaterials.InfestedMountains, atlasX, atlasZ, rotVector);
        }

    }

}