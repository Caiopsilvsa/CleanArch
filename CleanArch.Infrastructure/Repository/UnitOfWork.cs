using CleanArch.Application.Repositories;

namespace CleanArch.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
	public UnitOfWork(IContactRepository contactRepository)
	{
        ContactRepository = contactRepository;
	}

	public IContactRepository ContactRepository { get; set; }
}
