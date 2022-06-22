namespace JoyIT.MoviePlace.Common.Model.Interface
{
    public interface IBusinessDTO<TEntity> where TEntity : class
    {
        public TEntity ToEntity();
    }
}
