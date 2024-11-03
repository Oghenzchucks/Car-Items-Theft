using System;
using System.Collections.Generic;
using Controllers.GamePlay.Locomotion;
using Controllers.InputHandlers.Enums;
using Controllers.InputHandlers.Interfaces;
using Controllers.InputHandlers.Models;
using UnityEngine;

namespace Controllers.GamePlay.Map
{
    public class MapManager : MonoBehaviour, IInputListener
    {
        [SerializeField] private List<Transform> gridRows;        
        [SerializeField] private List<GridSpot> gridSpots;

        [SerializeField] private SaloonCar saloonCar;
        [SerializeField] private GridSpot startSpot;
        private GridSpot _endSpot;

        private bool _isDriving;
        
        private void Awake()
        {
            saloonCar.transform.position = startSpot.transform.position;
            LoadGridSpots();
            LoadGridSpotDirections();
            InputActionHandler.AddListener(this);
        }

        private void OnDisable()
        {
            InputActionHandler.RemoveListener(this);
        }

        private void LoadGridSpots()
        {
            for (var i = 0; i < gridRows.Count; i++)
            {
                var gridRow = gridRows[i];
                var spots = gridRow.GetComponentsInChildren<GridSpot>();
                for (var a = 0; a < spots.Length; a++)
                {
                    var spot = spots[a];
                    spot.LoadID(new Vector2(a + 1, i + 1));
                    gridSpots.Add(spot);
                }
            }
        }

        private void LoadGridSpotDirections()
        {
            var count = Enum.GetValues (typeof(DirectionType)).Length;

            foreach (var gridSpot in gridSpots)
            {
                for (int i = 0; i < count; i++)
                {
                    var direction = (DirectionType)i;
                    var directionGridSpot = GetGridSpot(gridSpot.GetDirectionSpotID(direction));
                    
                    if (directionGridSpot == null)
                    {
                        continue;
                    }
                    
                    var distance = Vector2.Distance(gridSpot.transform.position, directionGridSpot.transform.position);
                    gridSpot.LoadSpotData(direction, distance, directionGridSpot);
                }
            }
        }

        private GridSpot GetGridSpot(Vector2 id)
        {
            return gridSpots.Find(x => x.GetSpotID == id);
        }
        
        public void OnInputFired(InputData inputData)
        {
            switch (inputData.InputEnum)
            {
                case InputEnum.KEY:
                {
                    var keyInputData = (KeyInputData)inputData;
                    switch (keyInputData.KeyInputEnum)
                    {
                        case KeyInputEnum.LEFT_ARROW:
                            SetDestination(DirectionType.LEFT);
                            break;
                        case KeyInputEnum.RIGHT_ARROW:
                            SetDestination(DirectionType.RIGHT);
                            break;
                        case KeyInputEnum.UP_ARROW:
                            SetDestination(DirectionType.UP);
                            break;
                        case KeyInputEnum.DOWN_ARROW:
                            SetDestination(DirectionType.DOWN);
                            break;
                    }

                    break;
                }
                case InputEnum.CANVAS:
                {
                    var canvasInputData = (CanvasInputData)inputData;
                    switch (canvasInputData.CanvasInputEnum)
                    {
                        case CanvasInputEnum.MOVE_LEFT:
                            SetDestination(DirectionType.LEFT);
                            break;
                        case CanvasInputEnum.MOVE_RIGHT:
                            SetDestination(DirectionType.RIGHT);
                            break;
                        case CanvasInputEnum.MOVE_UP:
                            SetDestination(DirectionType.UP);
                            break;
                        case CanvasInputEnum.MOVE_DOWN:
                            SetDestination(DirectionType.DOWN);
                            break;
                    }

                    break;
                }
            }
        }

        private void SetDestination(DirectionType directionType)
        {
            if (_isDriving)
            {
                Debug.Log("Not collecting input");
                return;
            }
            
            _endSpot = startSpot.GetEndPoint(directionType);
            
            if (_endSpot == null)
            {
                Debug.Log("No Path there");
                return;
            }

            _endSpot.SetHighlight(true);
            saloonCar.StartCar(Vector3.Distance(startSpot.transform.position, _endSpot.transform.position));
            _isDriving = true;
        }

        private void Update()
        {
            if (_isDriving)
            {
                saloonCar.DriveToDestination(startSpot.transform.position, _endSpot.transform.position, OnArrived);
            }
        }

        private void OnArrived()
        {
            Debug.Log("Has Arrived");
            _isDriving = false;
            _endSpot.SetHighlight(false);
            startSpot = _endSpot;
        }
    }
}
