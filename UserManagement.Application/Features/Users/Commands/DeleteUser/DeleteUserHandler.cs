using Ardalis.Result;
using MediatR;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IGenericRepository<User> _repository;

        public DeleteUserHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(command.Id);
            if (user == null)
                return Task.FromResult(Result.NotFound("User not found"));

            _repository.Delete(command.Id);
            return Task.FromResult(Result.Success());
        }
    }
}
