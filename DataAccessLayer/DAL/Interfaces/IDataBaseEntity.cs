namespace DataAccessLayer.DAL.Interfaces
{
    /// <summary>
    /// Interface for EF entities
    /// for purpose of exposing identifier
    /// </summary>
    public interface IDataBaseEntity
    {
        int Id { get; set; }
    }
}
