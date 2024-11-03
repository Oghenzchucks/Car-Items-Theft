using System;

namespace Controllers.GamePlay.Map
{
    public static class MapModels
    {
        [Serializable]
        public struct DirectionGridSpot
        {
            public DirectionType directionType;
            public float distance;
            public GridSpot gridSpot;
            
            public DirectionGridSpot(DirectionType directionType, float distance, GridSpot gridSpot)
            {
                this.directionType = directionType;
                this.distance = distance;
                this.gridSpot = gridSpot;
            }
        }
    }
}
