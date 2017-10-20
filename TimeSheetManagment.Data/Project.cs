namespace TimeSheetManagment.Data
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
