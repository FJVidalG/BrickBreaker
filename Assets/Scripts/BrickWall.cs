using UnityEngine;

public class BrickWall : MonoBehaviour
{
    public GameObject[] brickPrefabs;

    void Start()
    {
        PlaceBricks();
    }


    void PlaceBricks(int nRows = 5, int nCols = 5, float gap = 0.5f)
    {

        Vector2 brickSize = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size;
        float brickWidth = brickSize.x;
        float brickHeight = brickSize.y;

        float totalWidth = nCols * brickWidth + (nCols - 1) * gap;
        float totalHeight = nRows * brickHeight + (nRows - 1) * gap;

        float startX = -(totalWidth - brickWidth) / 2;
        float startY = +(totalHeight - brickHeight) / 2;

        float offsetX = brickWidth + gap;
        float offsetY = brickHeight + gap;

        for (int row = 0; row < nRows; row++)
        {
            GameObject prefab = brickPrefabs[row % brickPrefabs.Length];

            for (int col = 0; col < nCols; col++)
            {
                float x = startX + col * offsetX;
                float y = startY - row * offsetY;
                Vector2 position = new Vector2(x, y);

                GameObject brick = Instantiate(prefab, (Vector2)transform.position + position, Quaternion.identity);
                brick.transform.SetParent(this.transform);
            }
        }
    }
}
