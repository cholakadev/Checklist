namespace Checlist.Domain.DomainModels.Action
{
    public static class ActionFactory
    {
        public static Action ToModel(this Models.Action action) =>
            new Action
            {
                Id = action.Id,
                Name = action.Name,
                State = action.State,
                Date = action.Date,
                DateString = action.Date.ToString("dd MMM, yyyy")
            };

        public static string Truncate(this string source, int length)
        {
            if (source.Length > length)
            {
                source = $"{source.Substring(0, length)}...";
            }

            return source;
        }
    }
}
