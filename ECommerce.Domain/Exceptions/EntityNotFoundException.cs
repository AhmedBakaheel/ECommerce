using System;

namespace ECommerce.Domain.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(object id)
            : base($"Entity of type '{typeof(T).Name}' with ID '{id}' was not found.")
        {
        }
    }
}