﻿using CSharpRPG.Core;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRPG.Systems
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly DungeonMap _map;

        // Constructing a new Map Generator requires the dimensions of the maps it will create
        public MapGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            _map = new DungeonMap();
        }

        // Generate a new map that is a simple open floor with walls around the outside
        public DungeonMap CreateMap()
        {
            // Initialize every cell in the map by 
            // setting walkable, transparancy, and explored to true
            _map.Initialize(_width, _height);
            foreach (Cell cell in _map.GetAllCells())
            {
                _map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            // Set the first and last rows in the map to not be transparant or walkable
            foreach (Cell  cell in _map.GetCellsInRows(0, _height - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            // Set the first and last columns in the map to not be transparant or walkable
            foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }
            return _map;
        }
    }
}
