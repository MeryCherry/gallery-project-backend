using BusinessLayer.AppEntities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.DAL.Interfaces
{
    /// <summary>
    /// Contains methods for data manipulation in database
    /// for DataAccessLayer
    /// </summary>
    /// <typeparam name="TBLL">Business logic entity</typeparam>
    public interface IBaseEntityDAL<TBLL> where TBLL : class, IBaseEntity
    {
        /// <summary>
        /// Get list of entites
        /// </summary>
        /// <returns>list of entites</returns>
        IPaginate<TBLL> Select();

        /// <summary>
        /// get entity by id
        /// </summary>
        /// <param name="id">identifier of entity to be returned</param>
        /// <returns></returns>
        TBLL Get(int id);

        /// <summary>
        /// Adds entity to list
        /// </summary>
        /// <param name="entity">entity to be added</param>
        void Add(TBLL entity);

        /// <summary>
        /// Delete entity from list
        /// </summary>
        /// <param name="entity">entity to be deleted</param>
        void Delete(TBLL entity);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id">identyfier of entity to be deleted</param>
        void Delete(int id);

        /// <summary>
        /// updates entity from list
        /// </summary>
        /// <param name="entity">entity to be updated</param>
        void Update(TBLL entity);
    }
}
