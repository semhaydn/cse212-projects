/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Moves left if allowed; otherwise, throws an exception.
    /// </summary>
    public void MoveLeft()
    {
        // Retrieve the valid movements for the current cell.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // Index 0 corresponds to left.
        if (!directions[0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--;
    }

    /// <summary>
    /// Moves right if allowed; otherwise, throws an exception.
    /// </summary>
    public void MoveRight()
    {
        // Retrieve the valid movements for the current cell.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // Index 1 corresponds to right.
        if (!directions[1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    /// <summary>
    /// Moves up if allowed; otherwise, throws an exception.
    /// </summary>
    public void MoveUp()
    {
        // Retrieve the valid movements for the current cell.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // Index 2 corresponds to up.
        if (!directions[2])
            throw new InvalidOperationException("Can't go that way!");
        _currY--;
    }

    /// <summary>
    /// Moves down if allowed; otherwise, throws an exception.
    /// </summary>
    public void MoveDown()
    {
        // Retrieve the valid movements for the current cell.
        bool[] directions = _mazeMap[(_currX, _currY)];
        // Index 3 corresponds to down.
        if (!directions[3])
            throw new InvalidOperationException("Can't go that way!");
        _currY++;
    }

    /// <summary>
    /// Returns the current location in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
