namespace Solid.ISP
{
    /// <summary>
    /// Super-Interface was mehrere Interfaces vereint
    /// *** Bitte nicht nachmachen! *** Verstoß gegen ISP! ***
    /// Warum? Unendlich viele Kombinationsmoeglichkeiten denkbar.
    /// </summary>
    public interface IHuman : IChef, IEat, ISleep
    {
    }
}
