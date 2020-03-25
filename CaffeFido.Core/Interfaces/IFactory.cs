using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaffeFido.Core.Interfaces
{
    public interface IFactory<T, in TKey>
    {
        /// <summary>
        /// Create an instance of <typeparam name="T"></typeparam>
        /// </summary>
        /// <returns></returns>
        T Create();

        /// <summary>
        /// Get an entity <typeparamref name="T"></typeparamref> by key <typeparamref name="TKey"/>
        /// </summary>
        /// <param name="key">The key to uniquely identity the <typeparamref name="T"></typeparamref> </param>
        /// <param name="cancellationToken"></param>
        /// <returns>The entity <typeparamref name="T"></typeparamref></returns>
        Task<T> GetByKeyAsync(TKey key, CancellationToken cancellationToken = new CancellationToken());
    }
}
