using Domain.Interfaces;
using Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class GetByidHandler<T> : IRequestHandler<GetGenericQueryById<T>, T> where T : class
    {
        private readonly IGenericRepository<T> repositry;
        public GetByidHandler(IGenericRepository<T> Repositry)
        {
            repositry = Repositry;
        }
        public Task<T> Handle(GetGenericQueryById<T> request, CancellationToken cancellationToken)
        {
            var resultat = repositry.Get(request.Condition, request.Includes);
            return Task.FromResult(resultat);
        }
    }
}
