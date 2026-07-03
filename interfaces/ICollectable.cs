public interface ICollectable
{
    public int   Strength      { get; set; }
    public int   Cost          { get; set; }
    public float SpawnInterval { get; set; }

    public void Collect(Game game)
    {
        game.AddCurrency(Cost);
    }
    
    public void DecreaseStrength()
    {
        Strength -= 1;
    }
}