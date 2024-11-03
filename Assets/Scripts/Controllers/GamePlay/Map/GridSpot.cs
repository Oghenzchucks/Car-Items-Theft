using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.GamePlay.Map
{
    public class GridSpot : MonoBehaviour
    {
        [SerializeField] private Vector2 spotID;
        [SerializeField] private List<MapModels.DirectionGridSpot> spotData;
        [SerializeField] private Image image;
        
        public Vector2 GetSpotID => spotID;

        public void LoadID(Vector2 id)
        {
            spotID = id;
        }

        public void LoadSpotData(DirectionType directionType, float distance, GridSpot gridSpot)
        {
            spotData.Add(new MapModels.DirectionGridSpot(directionType, distance, gridSpot));
        }

        public Vector2 GetDirectionSpotID(DirectionType directionType)
        {
            switch (directionType)
            {
                case DirectionType.LEFT:
                    return new Vector2(spotID.x - 1, spotID.y);
                case DirectionType.RIGHT:
                    return new Vector2(spotID.x + 1, spotID.y);
                case DirectionType.UP:
                    return new Vector2(spotID.x, spotID.y - 1);
                case DirectionType.DOWN:
                    return new Vector2(spotID.x, spotID.y + 1);
            }
            
            return Vector2.zero;
        }
        
        public GridSpot GetEndPoint(DirectionType directionType)
        {
            return spotData.Exists(x => x.directionType == directionType) ? spotData.Find(x => x.directionType == directionType).gridSpot : null;
        }

        public void SetHighlight(bool isDestination)
        {
            image.color = isDestination ? Color.red : Color.black;
        }
    }
}
