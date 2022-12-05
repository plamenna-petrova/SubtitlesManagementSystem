namespace SubtitlesManagementSystem.Business.Transactions.Interfaces
{
    public interface IUnitOfWork
    {
        bool CommitSaveChanges();
    }
}
