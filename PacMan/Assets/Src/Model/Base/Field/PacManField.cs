using Game.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Game.Model.ModelBase;

public class PacManField
{

    public static FieldCell[,] field = new FieldCell[16,12];


    public static void Init()
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 12; j++)
            {
               
                field[i, j] = new FieldCell(i, j);
            }
        }

        setWalls();


    }


    private static void setWalls()
    {
        field[3, 1].SetWall(eDirection.DOWN);
        field[4, 1].SetWall(eDirection.DOWN);
        field[5, 1].SetWall(eDirection.DOWN);
        field[6, 1].SetWall(eDirection.DOWN);

      
        field[9, 1].SetWall(eDirection.DOWN);
        field[10, 1].SetWall(eDirection.DOWN);
        field[11, 1].SetWall(eDirection.DOWN);
        field[12, 1].SetWall(eDirection.DOWN);

        field[3, 2].SetWall(eDirection.UP);
        field[4, 2].SetWall(eDirection.UP, eDirection.LEFT);
        field[5, 2].SetWall(eDirection.UP, eDirection.RIGHT);
        field[6, 2].SetWall(eDirection.UP);

        field[9, 2].SetWall(eDirection.UP);
        field[10, 2].SetWall(eDirection.UP, eDirection.LEFT);
        field[11, 2].SetWall(eDirection.UP, eDirection.RIGHT);
        field[12, 2].SetWall(eDirection.UP);


        field[3, 3].SetWall(eDirection.LEFT);
        field[4, 3].SetWall(eDirection.RIGHT, eDirection.LEFT);
        field[5, 3].SetWall(eDirection.RIGHT);

        field[10, 3].SetWall(eDirection.LEFT);
        field[11, 3].SetWall(eDirection.RIGHT, eDirection.LEFT);
        field[12, 3].SetWall(eDirection.RIGHT);

        field[2, 4].SetWall(eDirection.DOWN);
        field[3, 4].SetWall(eDirection.LEFT, eDirection.DOWN);
        field[4, 4].SetWall(eDirection.RIGHT);
        field[5, 4].SetWall(eDirection.DOWN);
        field[6, 4].SetWall(eDirection.DOWN);

        field[7, 4].SetWall(eDirection.LEFT);
        field[8, 4].SetWall(eDirection.RIGHT);
        field[9, 4].SetWall(eDirection.DOWN);
        field[10, 4].SetWall(eDirection.DOWN);

        field[11, 4].SetWall(eDirection.LEFT);
        field[12, 4].SetWall(eDirection.RIGHT, eDirection.DOWN);
        field[13, 4].SetWall(eDirection.DOWN);

        field[2, 5].SetWall(eDirection.UP);
        field[3, 5].SetWall(eDirection.UP);
        field[5, 5].SetWall(eDirection.UP);
        field[6, 5].SetWall(eDirection.UP);

        field[7, 5].SetWall(eDirection.LEFT);
        field[8, 5].SetWall(eDirection.RIGHT);

        field[9, 5].SetWall(eDirection.UP);
        field[10, 5].SetWall(eDirection.UP);
        field[12, 5].SetWall(eDirection.UP);
        field[13, 5].SetWall(eDirection.UP);


        field[2, 6].SetWall(eDirection.DOWN);
        field[3, 6].SetWall(eDirection.DOWN);
        field[4, 6].SetWall(eDirection.LEFT);
        field[5, 6].SetWall(eDirection.RIGHT);
        field[7, 6].SetWall(eDirection.LEFT, eDirection.DOWN);
        field[8, 6].SetWall(eDirection.RIGHT, eDirection.DOWN);
        field[10, 6].SetWall(eDirection.LEFT);
        field[11, 6].SetWall(eDirection.RIGHT);
        field[12, 6].SetWall(eDirection.DOWN);
        field[13, 6].SetWall(eDirection.DOWN);

        field[2, 7].SetWall(eDirection.UP, eDirection.LEFT);
        field[3, 7].SetWall(eDirection.UP, eDirection.RIGHT);
        field[4, 7].SetWall(eDirection.LEFT);
        field[5, 7].SetWall(eDirection.RIGHT);
        field[6, 7].SetWall(eDirection.DOWN);
        field[7, 7].SetWall(eDirection.DOWN, eDirection.UP);
        field[8, 7].SetWall(eDirection.DOWN, eDirection.UP);

        field[10, 7].SetWall(eDirection.LEFT);
        field[11, 7].SetWall(eDirection.RIGHT);
        field[12, 7].SetWall(eDirection.LEFT, eDirection.UP);
        field[13, 7].SetWall(eDirection.RIGHT, eDirection.UP);

        field[2, 8].SetWall(eDirection.LEFT);
        field[3, 8].SetWall(eDirection.RIGHT);

        field[5, 8].SetWall(eDirection.LEFT);
        field[6, 8].SetWall(eDirection.RIGHT, eDirection.UP);
        field[6, 8].SetWall(eDirection.UP);
        field[8, 8].SetWall(eDirection.LEFT,eDirection.UP);
        field[9, 8].SetWall(eDirection.RIGHT);

        field[12, 8].SetWall(eDirection.LEFT);
        field[13, 8].SetWall(eDirection.RIGHT, eDirection.UP);

        field[2, 9].SetWall(eDirection.LEFT);
        field[3, 9].SetWall(eDirection.RIGHT, eDirection.LEFT);
        field[4, 9].SetWall(eDirection.RIGHT);
                 
        field[5, 9].SetWall(eDirection.LEFT);
        field[6, 9].SetWall(eDirection.RIGHT, eDirection.DOWN);
                 
        field[8, 9].SetWall(eDirection.LEFT, eDirection.DOWN);
        field[9, 9].SetWall(eDirection.RIGHT);

        field[11, 9].SetWall(eDirection.LEFT);
        field[12, 9].SetWall(eDirection.LEFT, eDirection.RIGHT);
        field[13, 9].SetWall(eDirection.RIGHT);


        field[2, 10].SetWall(eDirection.LEFT);
        field[3, 10].SetWall(eDirection.RIGHT, eDirection.LEFT);
        field[4, 10].SetWall(eDirection.RIGHT, eDirection.DOWN);
                 
        field[5, 10].SetWall(eDirection.DOWN);
        field[6, 10].SetWall(eDirection.UP);
               
        field[8, 10].SetWall(eDirection.UP);
        field[10, 10].SetWall(eDirection.DOWN);

        field[11, 10].SetWall(eDirection.LEFT, eDirection.DOWN);
        field[12, 10].SetWall(eDirection.LEFT, eDirection.RIGHT);
        field[13, 10].SetWall(eDirection.RIGHT);

        field[4, 11].SetWall(eDirection.UP);
        field[5, 11].SetWall(eDirection.UP);

        field[10, 11].SetWall(eDirection.UP);
        field[11, 11].SetWall(eDirection.UP);


    }

    // none = 0
    // up = 1
    // down = 2
    // left = 3
    // right = 4




}
