namespace TimeSheetManagment.Data
{
    public class Tasks : IEntity<int>
    {
       
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int Id { get; set ; }
    }
}
