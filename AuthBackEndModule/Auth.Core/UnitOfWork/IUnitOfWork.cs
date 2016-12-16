namespace Auth.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
    }
}