using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Comands
{
    public  class DeleteGeneric<T> : IRequest<string> where T : class
    {

        public Guid Id { get; set; }
        public DeleteGeneric(Guid id)
        {
            Id = id;

        }
    }
}
