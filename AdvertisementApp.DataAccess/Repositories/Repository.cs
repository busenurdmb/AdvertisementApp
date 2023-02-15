using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Context;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Repositories
{
   public class Repository<T>: IRepository<T> where T:BaseEntity
    {
        private readonly AdvertisementContext _advertisementContext;

        public Repository(AdvertisementContext advertisementContext)
        {
            _advertisementContext = advertisementContext;
        }
        //orderby veriler sıralı gelsin
        //veriyi getirme
        //veriyi sıralayarak getirme
        //veriyi filtreleyerek getirme
        //asnotracking
        public async  Task<List<T>> GetAllAsync()
        {
            //bütün listeyi getiren
            return await _advertisementContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            return await _advertisementContext.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selecter, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _advertisementContext.Set<T>().AsNoTracking().OrderBy(selecter).ToListAsync() :
             await _advertisementContext.Set<T>().AsNoTracking().OrderByDescending(selecter).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T,TKey>>  selecter, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _advertisementContext.Set<T>().Where(filter).AsNoTracking().OrderBy(selecter).ToListAsync() :
            await _advertisementContext.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selecter).ToListAsync();
        }
        public async Task<T> FindAsync(object id)
        {
            return await _advertisementContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter , bool asNoTracking=false)
        {
            return asNoTracking?
                await _advertisementContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                await _advertisementContext.Set<T>().SingleOrDefaultAsync(filter);
        }
        public IQueryable<T> GetQuery()
        {
            return  _advertisementContext.Set<T>().AsQueryable();
        }
       
        public void Remove(T entity)
        {
            _advertisementContext.Set<T>().Remove(entity);
        }
        public async Task CreateAsync(T entity)
        {
           await _advertisementContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity,T unchanged)
        {
            _advertisementContext.Entry(unchanged).CurrentValues.SetValues(entity);
        }

    }
}
