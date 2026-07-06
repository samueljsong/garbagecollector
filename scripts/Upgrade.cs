using Godot;

public class Upgrade
{
    public string Information    { get; set; }
    public int    Level          { get; set; }
    public int    BaseCost       { get; set; }
    public float  CostGrowthRate { get; set; }
    public int    BasePower      { get; set; }
    public int    PowerIncrease  { get; set; }

    public int GetCost()
    {
        return Mathf.RoundToInt(BaseCost * Mathf.Pow(CostGrowthRate, Level));
    }

    public int GetPower()
    {
        return BasePower + Level * PowerIncrease;
    }
}