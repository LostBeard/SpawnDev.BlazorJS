namespace SpawnDev.BlazorJS.Test.GameOfLife
{
    [Flags]
    public enum BoardTileState : byte
    {
        /// <summary>
        /// Void of life now and has never been alive
        /// </summary>
        Void = 0,
        /// <summary>
        /// Any cell that was once alive, but is currently dead
        /// </summary>
        Dead = 1,
        /// <summary>
        /// Any live cell with fewer than two live neighbors dies, as if by underpopulation.
        /// </summary>
        DeathUnderPopulation = 2 | Dead,
        /// <summary>
        /// Any live cell with more than three live neighbors dies, as if by overpopulation.
        /// </summary>
        DeathOverPopulation = 4 | Dead,
        /// <summary>
        /// Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
        /// </summary>
        Alive = 8,
        Birth = 16 | Alive,
        Youngling = 32 | Alive,
        Adult = 64 | Alive,
        Elder = 128 | Alive,
    }
}
