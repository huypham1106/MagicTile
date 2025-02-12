using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hawki;

public class ScoreSystem : Singleton<ScoreSystem>
{

    private int totalScore;


    public void ResetScore()
    {
        totalScore = 0;
    }    
    public int GetPointShortNode()
    {
        return 3;
    }

    public int GetPointLongNode()
    {
        return 3;
    }    


    public int TotalScore()
    {
        return totalScore;
    }
    public PointData CalculatePoint(NodeState nodeState)
    {
        PointData pointData = new PointData();

        int calculatedPoint = 0;
        switch (nodeState)
        {
            case NodeState.Fast:
                calculatedPoint = 1;
                break;
            case NodeState.VeryFast:
                calculatedPoint = 2;
                break;
            case NodeState.TopSpeed:
                calculatedPoint = 3;
                break;
            default:
                break;
        }
        totalScore += calculatedPoint;

        pointData.CalculatedPoint = calculatedPoint;
        pointData.TotalPoint = totalScore;
        pointData.NodeState = nodeState;

        return pointData;
    }

}

public class PointData
{
    public int CalculatedPoint;
    public int TotalPoint;
    public NodeState NodeState;
}