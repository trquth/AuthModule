using Auth.Core.Interfaces.Repositories;
using Auth.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Auth.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public virtual TEntity Insert(TEntity dto)
        {
            TEntity entity = null;

            try
            {
                using (var db = new AuthContext())
                {
                    entity = db.Set<TEntity>().Add(dto);
                    db.SaveChanges();
                    //TEntity = dto;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                entity = null;
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
                entity = null;
            }
            catch (Exception ex)
            {
                entity = null;
                //Logger.Error(ex.Message, ex);
            }

            return entity;
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> list)
        {
            using (var db = new AuthContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    IEnumerable<TEntity> tList = null;
                    try
                    {
                        tList = db.Set<TEntity>().AddRange(list);
                        db.SaveChanges();
                        trans.Commit();//Data Saved Successfully. Transaction Commited
                                       //tList = list;
                    }
                    catch (DbException ex)
                    {
                        //Logger.Error(ex.Message, ex);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();//Error Occured during data saved. Transaction Rolled Back
                        //Logger.Error(ex.Message, ex);
                    }
                    return tList;
                }
            }
        }

        public virtual TEntity Update(TEntity dto)
        {
            TEntity entity = null;

            try
            {
                using (var db = new AuthContext())
                {
                    entity = db.Set<TEntity>().Find(dto.Id);
                    if (entity != null)
                    {
                        db.Entry(entity).CurrentValues.SetValues(dto);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                entity = null;
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
                entity = null;
            }
            catch (Exception ex)
            {
                entity = null;
                //Logger.Error(ex.Message, ex);
            }

            return entity;
        }

        public virtual bool Update(List<TEntity> dtoList)
        {
            using (var db = new AuthContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    TEntity entity = null;
                    try
                    {

                        var dbSet = db.Set<TEntity>();
                        dtoList.ForEach(x =>
                        {
                            entity = dbSet.Find(x.Id);
                            if (entity != null)
                            {
                                db.Entry(entity).CurrentValues.SetValues(x);
                            }
                        });

                        db.SaveChanges();
                        trans.Commit();//Data Saved Successfully. Transaction Commited
                        return true;

                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                            }
                        }
                        return false;
                    }
                    catch (DbException ex)
                    {
                        //Logger.Error(ex.Message, ex);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();//Error Occured during data saved. Transaction Rolled Back
                        //Logger.Error(ex.Message, ex);
                        return false;
                    }
                }
            }
        }

        public virtual TEntity GetById(Guid id)
        {
            TEntity entity = null;

            try
            {
                using (var db = new AuthContext())
                {
                    entity = db.Set<TEntity>().Find(id);
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return entity;
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> result = null;

            try
            {
                using (var db = new AuthContext())
                {
                    result = db.Set<TEntity>().Where(i => !i.IsDeleted).Where(predicate).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }

        public virtual TEntity SingleBy(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = null;

            try
            {
                using (var db = new AuthContext())
                {
                    entity = db.Set<TEntity>().Where(i => !i.IsDeleted).FirstOrDefault(predicate);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> result = null;

            try
            {
                using (var db = new AuthContext())
                {
                    result = db.Set<TEntity>().Where(i => !i.IsDeleted).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetRange(int pageIndex, int pageSize)
        {
            IEnumerable<TEntity> result = null;

            try
            {
                using (var db = new AuthContext())
                {
                    result = db.Set<TEntity>().Where(i => !i.IsDeleted).OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetRange(int pageIndex, int pageSize, out int count)
        {
            IEnumerable<TEntity> result = null;
            count = 0;
            try
            {
                using (var db = new AuthContext())
                {
                    var list = db.Set<TEntity>().Where(i => !i.IsDeleted);
                    count = list.Count();
                    result = list.OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }


        public virtual IEnumerable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            IEnumerable<TEntity> result = null;

            try
            {
                using (var db = new AuthContext())
                {
                    result = db.Set<TEntity>().Where(i => !i.IsDeleted).Where(predicate).OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            IEnumerable<TEntity> result = null;

            try
            {
                using (var db = new AuthContext())
                {
                    var list = db.Set<TEntity>().Where(i => !i.IsDeleted).Where(predicate).ToList();
                    count = list.Count();
                    result = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return result ?? Enumerable.Empty<TEntity>();
        }
        public TEntity Delete(TEntity dto)
        {
            TEntity entity = null;

            try
            {
                using (var db = new AuthContext())
                {
                    entity = db.Set<TEntity>().Find(dto.Id);
                    if (entity != null)
                    {
                        //entity.IsDeleted = true;
                        entity = db.Set<TEntity>().Remove(entity);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
            catch (DbException ex)
            {
                //Logger.Error(ex.Message, ex);
                entity = null;
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }

            return entity;
        }


    }
}
