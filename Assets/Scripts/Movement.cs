using UnityEngine;

public class Movement 
{
    #region Properties
    private string movementName;
    #endregion

    #region Getter
    public string MovementName => movementName;
    #endregion

    #region Constructor
    public Movement(string name)
    {
        movementName = name;
    }
    #endregion
}
