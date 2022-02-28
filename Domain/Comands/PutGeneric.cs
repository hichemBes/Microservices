using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Comands
{
    public  class PutGeneric<T>:IRequest<string > where T :class 
    {
        public T Obj { get; set; }
        public PutGeneric(T obj)
        {
            Obj = obj; 

        }
    }
}
