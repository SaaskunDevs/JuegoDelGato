using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UserTurnGrid : MonoBehaviour
{
    [SerializeField] private Material gridMat;

    public float actualTime;
    public float changeActuaTime;
    private float changeTime = 0.5f;
    [SerializeField, ColorUsage(false, true)]
    private Color team1Color;
    [SerializeField, ColorUsage(false, true)]
    private Color team2Color;

    [ColorUsage(false, true)]
    public Color actualChangecolor;
    private int targetIndex;

    public bool animating;

    private void Update()
    {
        if(animating)
            AnimateColorGrid();

        if (Input.GetKeyDown(KeyCode.J))
            ChangeTeam(0);
        if (Input.GetKeyDown(KeyCode.K))
            ChangeTeam(1);

    }

    /// <summary>
    /// Cambio de team, 0 es X y 1 es O
    /// </summary>
    /// <param name="index"></param>
    public void ChangeTeam(int index)
    {
        if (targetIndex == index)
            return;


        if (index == 0)
            actualTime = 0;
        else
            actualTime = changeTime;



        targetIndex = index;
        animating = true;
    }


    void AnimateColorGrid()
    {


        if (targetIndex == 0)
        {
            actualTime += Time.deltaTime;
            actualChangecolor = Color.Lerp(team2Color, team1Color, actualTime / changeTime);
            gridMat.SetColor("_MainColor", actualChangecolor);

            if (actualTime >= changeTime)
            {
                actualTime = 0;
                changeActuaTime = 0;
                animating = false;
            }
        }


        if (targetIndex == 1)
        {
            actualTime -= Time.deltaTime;
            actualChangecolor = Color.Lerp(team2Color, team1Color, actualTime / changeTime);
            gridMat.SetColor("_MainColor", actualChangecolor);

            if (actualTime <= 0)
            {
                actualTime = 0;
                changeActuaTime = 0;
                animating = false;
            }
        }
    }
}
