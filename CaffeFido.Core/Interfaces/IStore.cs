using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaffeFido.Core.Interfaces
{
    public interface IStore<T>
    {
        /// <summary>
        /// Add an entity <typeparamref name="T"></typeparamref> 
        /// </summary>
        /// <param name="entity">The entity <typeparamref name="T"></typeparamref> to add</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The added entity <typeparamref name="T"></typeparamref> </returns>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = new CancellationToken());
        /// <summary>
        /// Update an entity <typeparamref name="T"></typeparamref> 
        /// </summary>
        /// <param name="entity">The entity <typeparamref name="T"></typeparamref> to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The updated entity <typeparamref name="T"></typeparamref> </returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = new CancellationToken());
    }
}
