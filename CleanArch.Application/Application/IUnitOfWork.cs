namespace CleanArch.Application.Repositories;

public interface IUnitOfWork
{
    IContactRepository ContactRepository { get; }
}
