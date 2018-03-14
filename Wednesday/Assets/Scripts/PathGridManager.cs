using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGridManager : MonoBehaviour{

    public Transform _playerTransform;
    public LayerMask _obstacleMask;
    public Vector2 _gridSize;
    public float _halfNodeWidth;
    public Node[,] _grid;
    public NeighborFinder _neighborFinder;

    int _gridWidth,
        _gridHeight;

    private void Start()
    {
        float nodeWidth = _halfNodeWidth * 2f;
        float nodeHeight = _halfNodeWidth * 2f;

        _gridWidth = (int)(_gridSize.x / nodeWidth);
        _gridHeight = (int)(_gridSize.y / nodeHeight);

        _grid = new Node[_gridWidth, _gridHeight];

        GenerateNodes();
    }

    private void GenerateNodes()
    {
        for (int i = 0; i < _gridHeight; i++)
        {
            for (int j = 0; j < _gridWidth; j++)
            {
                /*_grid[i, j] = new Node(false,
                    new Vector3((-_gridSize.x / 2) + _halfNodeWidth + (i * _halfNodeWidth * 2f),
                    _halfNodeWidth,
                    (-_gridSize.y / 2) + _halfNodeWidth + (j * _halfNodeWidth * 2f)),
                    i,
                    j);

                if (Physics.CheckSphere(_grid[i,j]._position,
                    _halfNodeWidth,
                    _obstacleMask))
                {
                    _grid[i, j]._isBlocked = true;
                }
                else
                {
                    _grid[i, j]._isBlocked = false;
                }*/
            }
        }
    }

    private void DrawNodes()
    {
        List<Node> _neighbors = null;

        for (int i = 0; i < _gridHeight; i++)
        {
            for (int j = 0; j < _gridWidth; j++)
            {
                /*if (_grid[i, j]._isBlocked == false)
                {
                    Gizmos.color = Color.black;
                }
                else
                {
                    Gizmos.color = Color.red;
                }

                if (_playerTransform.position.x < _grid[i, j]._position.x + _halfNodeWidth &&
                    _playerTransform.position.x > _grid[i, j]._position.x - _halfNodeWidth &&
                    _playerTransform.position.z < _grid[i, j]._position.z + _halfNodeWidth &&
                    _playerTransform.position.z > _grid[i, j]._position.z - _halfNodeWidth)
                {
                    Gizmos.color = Color.green;

                    _neighbors = _neighborFinder.ReturnNeighbors(_grid[i, j]);
                }

                if (_neighbors != null)
                {
                    if (_neighbors.Contains(_grid[i,j]))
                    {
                        Gizmos.color = Color.blue;
                    }
                }

                Gizmos.DrawWireCube(_grid[i, j]._position,
                    new Vector3(_halfNodeWidth * 2f, _halfNodeWidth * 2f, _halfNodeWidth * 2f));*/
            }
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(_gridSize.x, _halfNodeWidth, _gridSize.y));
        DrawNodes();
    }*/
}