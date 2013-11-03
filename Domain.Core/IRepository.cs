using System.Collections.Generic;

namespace Domain.Core
{
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Get the context in this repository.
        /// </summary>
        // IContext context { get; }

        /// <summary>
        /// Add item into repository.
        /// </summary>
        /// <param name="item">Item to add to the repository.</param>
        void Add(T item);

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        void Remove(T item);

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="item">Item to update.</param>
        void Update(T item);

        /// <summary>
        /// Get all elements of the type {T} in repository.
        /// </summary>
        /// <returns>List of selected elements.</returns>
        IEnumerable<T> GetAll();
    }
}

