namespace Checlist.DTOs
{
    public static class ActionFactory
    {
        public static Action ToDTO(this Models.Action action) =>
            new Action
            {
                Id = action.Id,
                Name = action.Name,
                Done = action.Done,
                Date = action.Date.ToString("dd MM yyyy")
            };
    }
}
