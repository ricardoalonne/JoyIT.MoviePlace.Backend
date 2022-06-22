namespace JoyIT.MoviePlace.Common.Model.Interface
{
    public interface IClone<TModel> where TModel : class
    {
        public TModel Clone(int id);
    }
}
