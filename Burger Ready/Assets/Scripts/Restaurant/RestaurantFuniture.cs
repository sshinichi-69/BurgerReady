using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Restaurant
{
    public class RestaurantFurniture : MonoBehaviour
    {
        [SerializeField] private GameObject floor;
        [SerializeField] private GameObject wall;

        [SerializeField] private GameObject floorPrefab;
        [SerializeField] private GameObject wallPrefab;

        private const int restaurantMaxX = 10;
        private const int restaurantMaxZ = 15;
        // Start is called before the first frame update
        void Start()
        {
            GenerateFloor();
            GenerateWall();
        }

        void GenerateFloor()
        {
            float k = 2.5f;
            int nHalfRowFloor = Mathf.RoundToInt(restaurantMaxZ / k);
            int nHalfColFloor = Mathf.RoundToInt(restaurantMaxX / k);
            for (int i = -nHalfRowFloor; i <= nHalfRowFloor; i++)
            {
                for (int j = -nHalfColFloor; j <= nHalfColFloor; j++)
                {
                    GameObject floorPiece = Instantiate(floorPrefab, new Vector3(j * k, 0, i * k), Quaternion.identity);
                    floorPiece.transform.parent = floor.transform;
                }
            }
        }

        void GenerateWall()
        {
            float k = 2.5f;
            int nHalfRowWall = Mathf.RoundToInt(restaurantMaxZ / k);
            int nHalfColWall = Mathf.RoundToInt(restaurantMaxX / k);
            // top
            for (int j = -nHalfColWall; j <= nHalfColWall; j++)
            {
                GameObject wallPiece = Instantiate(wallPrefab, new Vector3(j * k, 0, nHalfRowWall * k), Quaternion.identity);
                wallPiece.transform.parent = wall.transform;
            }
            // right
            for (int i = -nHalfRowWall; i <= nHalfRowWall; i++)
            {
                GameObject wallPiece = Instantiate(wallPrefab, new Vector3(nHalfColWall * k, 0, i * k), Quaternion.identity);
                wallPiece.transform.Rotate(new Vector3(0, 90, 0));
                wallPiece.transform.parent = wall.transform;
            }
            // bottom
            for (int j = -nHalfColWall; j <= nHalfColWall; j++)
            {
                GameObject wallPiece = Instantiate(wallPrefab, new Vector3(j * k, 0, -nHalfRowWall * k), Quaternion.identity);
                wallPiece.transform.Rotate(new Vector3(0, 180, 0));
                wallPiece.transform.parent = wall.transform;
            }
            // left
            for (int i = -nHalfRowWall; i <= nHalfRowWall; i++)
            {
                GameObject wallPiece = Instantiate(wallPrefab, new Vector3(-nHalfColWall * k, 0, i * k), Quaternion.identity);
                wallPiece.transform.Rotate(new Vector3(0, -90, 0));
                wallPiece.transform.parent = wall.transform;
            }
        }
    }
}
