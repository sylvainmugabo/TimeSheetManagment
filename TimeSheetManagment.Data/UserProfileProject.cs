namespace TimeSheetManagment.Data
{
    public class UserProfileProject : IEntity<int>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile  UserProfile { get; set; }
    }
}
