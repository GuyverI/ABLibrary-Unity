using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABLibrary
{
    public class Grid<T> : MonoBehaviour
    {
        public delegate void ElementOperator(ref T element);

        public struct Size
        {
            public int row;
            public int column;
        }

        public struct Position
        {
            public int row;
            public int column;
        }




        public Grid(int rows, int columns)
        {
            _grid = new T[rows, columns];
        }

        public int GetRowCount()
        {
            return _grid.GetLength(0);
        }

        public int GetColumnCount()
        {
            return _grid.GetLength(1);
        }

        public Size GetSize()
        {
            Size sz;
            sz.row = GetRowCount();
            sz.column = GetColumnCount();
            return sz;
        }

        public T Get(Position pos)
        {
            return Get(pos.row, pos.column);
        }

        public T Get(int row, int column)
        {
            return _grid[row, column];
        }

        public void Set(Position pos, T val)
        {
            Set(pos.row, pos.column, val);
        }

        public void Set(int row, int column, T val)
        {
            _grid[row, column] = val;
        }

        public void ForEach(ElementOperator op)
        {
            Size sz = GetSize();
            for (int row = 0; row < sz.row; ++row)
                for (int col = 0; col < sz.column; ++col)
                    op(ref _grid[row, col]);
        }




        private T[,] _grid = null;
    }
}


