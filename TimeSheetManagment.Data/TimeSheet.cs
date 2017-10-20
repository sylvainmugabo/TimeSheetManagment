namespace TimeSheetManagment.Data
{
    public class TimeSheet : IEntity<int>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public double Sunday { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wenesday { get; set; }
        public double Thusday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string ApprovedBy { get; set; }
        public string RejectedBy { get; set; }

    }
}
