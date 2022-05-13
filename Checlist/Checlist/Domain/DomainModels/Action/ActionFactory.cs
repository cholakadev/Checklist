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
                Date = action.Date.ToString("dd MMM, yyyy")
            };
    }
}
