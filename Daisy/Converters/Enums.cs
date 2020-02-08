namespace Daisy.Enums
{
    public enum ElectrodeStatus
    {
        Disconnected,               // black
        NotSelected,                // gray
        Selected,                   // yellow
        Ablating,                   // red
        PostAblation,               // red white gradient
        NoColoringIndicators        // dark red
    }

    public enum ElectrodeFluoroMarker
    {
        None,
        Rectangle,
        SolidTriangle,
        OutlineTriangle
    }

    public enum DeflectionDirection
    {
        North,
        East,
        South,
        West
    }
}
