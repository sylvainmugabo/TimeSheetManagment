namespace TimeSheetManagment.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }

    }
}
