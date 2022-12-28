namespace Delegate
{
    public static class ExtentionClass
    {
        public static T? GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) 
        {
            return e.OrderByDescending(x => getParameter(x)).FirstOrDefault();
        }

    }
}
