using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class TileMapData
    {
        public List<Rect> collisionRectList = new List<Rect>();

        public List<Bounds> collisionBoundsList = new List<Bounds>();

        public TileMapData(GameObject tileMapGameObject)
        {
            loadCollisionRectListFromPrefab(tileMapGameObject);
        }

        private void loadCollisionRectListFromPrefab(GameObject tileMapGameObject)
        {
            Transform collisionChild = tileMapGameObject.transform.FindChild("collision");

            foreach (var box in collisionChild.GetComponentsInChildren<BoxCollider2D>())
            {
                collisionBoundsList.Add(box.bounds);

                Rect tempRect = new Rect(box.transform.position.x + box.offset.x, box.transform.position.y + box.offset.y, box.size.x, box.size.y);
                collisionRectList.Add(tempRect);
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

        public bool checkCollision(Rect testRec)
        {
            foreach (var rect in collisionRectList)
            {
                if (rect.Overlaps(testRec))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
