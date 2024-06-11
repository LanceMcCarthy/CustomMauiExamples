namespace EFCoreDemos.Models.Tools;

public class AdaptorComparer<T>(System.Collections.IComparer telerikComparer) : System.Collections.Generic.IComparer<T>
{
    public int Compare(T? x, T? y)
    {
        return telerikComparer.Compare(x, y);
    }
}