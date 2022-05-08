namespace Checlist.DTOs
{
    public static class ActionFactory
    {
        public static Action ToModel(this Models.Action action) =>
            new Action
            {
                Id = action.Id,
                Name = action.Name,
                Done = action.Done,
                Date = action.Date.ToString("dd MMM, yyyy")
            };
    }
}
