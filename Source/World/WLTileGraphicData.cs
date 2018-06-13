﻿using System;
using System.Linq;
using System.Text;
using Verse;
using UnityEngine;

namespace TerraFW
{

    public class WLTileGraphicData
    {

        public Material material;
        public int texturesInAtlasX;
        public int texturesInAtlasZ;
        public int atlasX = 0;
        public int atlasZ = 0;
        public float sizeFactor = 1f;
        public float posOffset = 0f;
        public Vector3 rotVector = Vector3.up;

        public WLTileGraphicData()
        {
        }

        public WLTileGraphicData(Material material, FloatRange sizeFactor, FloatRange posOffset, bool randomRotation = true)
        {
            this.material = material;
            this.texturesInAtlasX = material.mainTexture.width / 256;
            this.texturesInAtlasZ = material.mainTexture.height / 256;
            this.atlasX = Rand.RangeInclusive(0, texturesInAtlasX - 1);
            this.atlasZ = Rand.RangeInclusive(0, texturesInAtlasZ - 1);
            this.sizeFactor = sizeFactor.RandomInRange;
            this.posOffset = posOffset.RandomInRange;
            if (randomRotation)
            {
                this.rotVector = Rand.UnitVector3;
            }
        }

        public WLTileGraphicData(Material material, int atlasX, int atlasZ, Vector3 rotVector)
        {
            this.material = material;
            this.texturesInAtlasX = material.mainTexture.width / 256;
            this.texturesInAtlasZ = material.mainTexture.height / 256;
            this.atlasX = atlasX;
            this.atlasZ = atlasZ;
            this.rotVector = rotVector;
        }

    }

}