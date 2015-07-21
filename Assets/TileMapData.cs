using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class TileMapData
    {
       

        public List<Bounds> collisionBoundsList = new List<Bounds>();
        public Bounds spawnBounds;

        public TileMapData(GameObject tileMapGameObject)
        {
            loadSpawn(tileMapGameObject);
            loadCollisionRectListFromPrefab(tileMapGameObject);
        }

        private void loadSpawn(GameObject tileMapGameObject)
        {
            Transform spawnChild = tileMapGameObject.transform.FindChild("spawn");
            spawnBounds = spawnChild.GetComponentsInChildren<BoxCollider2D>().FirstOrDefault().bounds;

        }

        private void loadCollisionRectListFromPrefab(GameObject tileMapGameObject)
        {
            Transform collisionChild = tileMapGameObject.transform.FindChild("collision");

            foreach (var box in collisionChild.GetComponentsInChildren<BoxCollider2D>())
            {
                collisionBoundsList.Add(box.bounds);

            }

        }

        public bool checkCollision(Bounds testBounds)
        {
            foreach (var b in collisionBoundsList)
            {
                if (b.Intersects(testBounds))
                {
                    return true;
                }
            }
            return false;
        }

      
    }
}
