using Auth.DTO.Models;
using Infrastructure;
using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Auth.DAO.Implements
{
    public abstract class GenericDAOImpl<TDto> : IGenericDao<TDto> where TDto : BaseDto
    {
        public virtual TDto Insert(TDto dto)
        {
            TDto TDto = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    TDto = db.Set<TDto>().Add(dto);
                    db.SaveChanges();
                    //TDto = dto;
                }
            }
            catch (Exception ex)
            {
                TDto = null;
                Logger.Error(ex.Message, ex);
            }

            return TDto;
        }
        public bool f_DeleteBySql(object[] a_LstIDs)
        {
            try
            {
                Type t = typeof(TDto);
                var tableAttributeTmp = t.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute), false);

                if (tableAttributeTmp.Count() == 0)
                {
                    return false;
                }
                var tableAttribute = (System.ComponentModel.DataAnnotations.Schema.TableAttribute)tableAttributeTmp.Single();
                using (var db = new ADMINMODULContext())
                {
                    var l_IDs = (from x in a_LstIDs
                                 select string.Format("'{0}'", x.ConvertToString())).ToArray();
                    var l_Cmd = string.Format("DELETE {0} Where Id IN ({1})", tableAttribute.Name, string.Concat(l_IDs).Replace("''", "','"));
                    db.Database.ExecuteSqlCommand(l_Cmd);
                }
            }
            catch (System.Exception ex)
            {
                // System.Data.Common.Util.Logger.Error("f_DeleteBySql: " + ex.Message + ex.StackTrace);
                return false;
            }
            return true;
        }
        public IEnumerable<TDto> Insert(IEnumerable<TDto> list)
        {
            using (var db = new ADMINMODULContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    IEnumerable<TDto> tList = null;
                    try
                    {
                        tList = db.Set<TDto>().AddRange(list);
                        db.SaveChanges();
                        trans.Commit();//Data Saved Successfully. Transaction Commited
                                       //tList = list;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();//Error Occured during data saved. Transaction Rolled Back
                        tList = null;
                        Logger.Error(ex.Message, ex);
                    }
                    return tList;
                }
            }
        }

        public static void TransformOnePropertyValue(TDto objSource, TDto objDestination, string propertyName)
        {
            var pr = typeof(TDto).GetProperties().FirstOrDefault(x => x.Name.ToLower() == propertyName.ToLower());
            if (pr.IsNotNull())
            {
                pr.SetValue(objDestination, pr.GetValue(objSource));
            }
        }
        public virtual TDto Update(TDto dto)
        {
            TDto TDto = null;
            try
            {
                using (var db = new ADMINMODULContext())
                {
                    TDto = db.Set<TDto>().Find(dto.Id);
                    if (TDto != null)
                    {
                        dto.Created = TDto.Created;
                        TransformOnePropertyValue(TDto, dto, "BillerId");
                        db.Entry(TDto).CurrentValues.SetValues(dto);
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
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                TDto = null;
                Logger.Error(ex.Message, ex);
            }

            return TDto;
        }

        public virtual bool Update(List<TDto> dtoList)
        {
            using (var db = new ADMINMODULContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    TDto TDto = null;
                    try
                    {

                        var dbSet = db.Set<TDto>();
                        dtoList.ForEach(x =>
                        {
                            TDto = dbSet.Find(x.Id);
                            if (TDto != null)
                            {
                                x.Created = TDto.Created;
                                TransformOnePropertyValue(TDto, x, "BillerId");
                                db.Entry(TDto).CurrentValues.SetValues(x);
                            }
                        });
                        //return (db.SaveChanges() >= 0);
                        db.SaveChanges();
                        trans.Commit();//Data Saved Successfully. Transaction Commited
                        return true;

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();//Error Occured during data saved. Transaction Rolled Back
                        Logger.Error(ex.Message, ex);
                        return false;
                    }
                }
            }
        }

        public virtual TDto GetById(Guid id)
        {
            TDto TDto = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    TDto = db.Set<TDto>().Find(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return TDto;
        }

        public virtual IEnumerable<TDto> FindBy(Expression<Func<TDto, bool>> predicate)
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).Where(predicate).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return result;
        }

        public virtual TDto SingleBy(Expression<Func<TDto, bool>> predicate)
        {
            TDto TDto = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    TDto = db.Set<TDto>().Where(i => i.IsDeleted == false).FirstOrDefault(predicate);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return TDto;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return result;
        }

        public virtual IEnumerable<TDto> GetRange(int pageIndex, int pageSize)
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return result;
        }

        public virtual IEnumerable<TDto> GetRange(Expression<Func<TDto, bool>> predicate, int pageIndex, int pageSize)
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).Where(predicate).OrderBy(i => i.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return result;
        }

        public TDto Delete(TDto dto)
        {
            TDto TDto = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    TDto = db.Set<TDto>().Find(dto.Id);
                    if (TDto != null)
                    {
                        TDto.IsDeleted = true;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

            return TDto;
        }

        public IEnumerable<TDto> GetRange(int pageIndex, int pageSize, out int total)
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).OrderBy(i => i.Id);
                    total = result.Count();
                    return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                total = 0;
                return null;
            }


        }

        public IEnumerable<TDto> GetRange(Expression<Func<TDto, bool>> predicate, int pageIndex, int pageSize, out int total)
        {
            IEnumerable<TDto> result = null;

            try
            {
                using (var db = new ADMINMODULContext())
                {
                    result = db.Set<TDto>().Where(i => i.IsDeleted == false).Where(predicate).OrderBy(i => i.Id);
                    total = result.Count();
                    return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                total = 0;
                return null;
            }
        }
    }
}
