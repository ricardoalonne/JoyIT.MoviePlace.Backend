namespace JoyIT.MoviePlace.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
