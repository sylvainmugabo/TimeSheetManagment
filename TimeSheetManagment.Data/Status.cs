namespace TimeSheetManagment.Data
{
    public class Status : IEntity<int>
    {
        public int Id { get; set ; }
        public string Description { get; set; }
        
    }
}