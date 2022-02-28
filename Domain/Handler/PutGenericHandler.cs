using Domain.Comands;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class PutGenericHandler<T> : IRequestHandler<PutGeneric<T>, string> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public PutGenericHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(PutGeneric<T> request, CancellationToken cancellationToken)
        {
            var res =repository.Update(request.Obj);
            return Task.FromResult(res);
        }
    }
}
