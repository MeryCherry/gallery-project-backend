using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Repository class, encapsulate database access
    /// cotains generic methods to operate on data
    /// </summary>
    /// <typeparam name="TDAL">database class</typeparam>
    /// <typeparam name="TBLL">mapped business logic class</typeparam>
    public class Repository<TDAL, TBLL> : BaseRepository<TDAL>, IRepository<TDAL, TBLL> where TDAL : class
    {
        public Repository(DbContext context) : base(context){ }


        /// <summary>
        /// Generic method for mapping between classes
        /// </summary>
        /// <typeparam name="Source">source class for mapping</typeparam>
        /// <typeparam name="Destiny">destiny class for mapping</typeparam>
        /// <param name="obj">object to be mapped</param>
        /// <returns></returns>
        protected virtual Destiny Map<Source,Destiny>(Source obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Source, Destiny>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Source, Destiny>(obj);
        }


        /// <summary>
        /// inserting record to database
        /// </summary>
        /// <param name="entity">entity to be inserted</param>
        public void Add(TBLL entity)
        {
            var res = Map<TBLL,TDAL>(entity);
            _dbSet.Add(res);
        }

        /// <summary>
        ///  inserting records to database
        /// </summary>
        /// <param name="entities">array of entities to be inserted</param>
        public void Add(params TBLL[] entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities);
            _dbSet.AddRange(res);
        }


        /// <summary>
        ///  inserting records to database
        /// </summary>
        /// <param name="entities">array of entities to be inserted</param>
        public void Add(IEnumerable<TBLL> entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities.ToArray());
            _dbSet.AddRange(res);
        }


        /// <summary>
        /// delete entity from DB
        /// </summary>
        /// <param name="entity">entity to be deleted</param>
        public void Delete(TBLL entity)
        {
            var res = Map<TBLL, TDAL>(entity);
            var existing = _dbSet.Find(res);
            if (existing != null) _dbSet.Remove(existing);
        }


        /// <summary>
        /// delete entity with given id from DB
        /// </summary>
        /// <param name="id">identifier of entity to be deleted</param>
        public void Delete(object id)
        {
            var typeInfo = typeof(TDAL).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TDAL>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null) Delete(entity);
            }
        }

        /// <summary>
        /// delete array of entities from DB
        /// </summary>
        /// <param name="entities">array to be deleted</param>
        public void Delete(params TBLL[] entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities);
            _dbSet.RemoveRange(res);
        }

        /// <summary>
        /// delete array of entities from DB
        /// </summary>
        /// <param name="entities">array to be deleted</param>
        public void Delete(IEnumerable<TBLL> entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities.ToArray());
            _dbSet.RemoveRange(res);
        }


        /// <summary>
        /// get list of entities from db
        /// </summary>
        /// <returns>list of entites</returns>
        [Obsolete("Method is replaced by GetList")]
        public IEnumerable<TBLL> Get()
        {
            var collection = _dbSet.AsEnumerable().ToArray();
            return Map<TDAL[], TBLL[] > (collection);
        }

        /// <summary>
        /// get list of entities from DB 
        /// </summary>
        /// <param name="predicate">condition for query</param>
        /// <returns>list of entites</returns>
        [Obsolete("Method is replaced by GetList")]
        public IEnumerable<TBLL> Get(Expression<Func<TDAL, bool>> predicate)
        {
            var collection = _dbSet.Where(predicate).AsEnumerable().ToArray();
             return Map<TDAL[], TBLL[]>(collection);
        }

        /// <summary>
        /// Edit entity in DB
        /// </summary>
        /// <param name="entity">entity to be updated</param>
        public void Update(TBLL entity)
        {
            var res = Map<TBLL,TDAL>(entity);
            _dbSet.Update(res);
        }

        /// <summary>
        /// Edit array of entities in DB
        /// </summary>
        /// <param name="entities">array of entites to be updated</param>
        public void Update(params TBLL[] entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities);
            _dbSet.UpdateRange(res);
        }


        /// <summary>
        /// Edit collection of entities in DB
        /// </summary>
        /// <param name="entities">collection of entites to be updated</param>
        public void Update(IEnumerable<TBLL> entities)
        {
            var res = Map<TBLL[], TDAL[]>(entities.ToArray());
            _dbSet.UpdateRange(res);
        }

        /// <summary>
        /// dispose context
        /// </summary>
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
