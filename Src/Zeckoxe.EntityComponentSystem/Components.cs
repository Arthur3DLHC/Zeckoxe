﻿using System.Runtime.CompilerServices;

namespace Zeckoxe.EntityComponentSystem
{
    /// <summary>
    /// Provides a fast access to the components of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    public readonly ref struct Components<T>
    {
        private readonly int[] _mapping;
        private readonly T[] _components;

        internal Components(int[] mapping, T[] components)
        {
            _mapping = mapping;
            _components = components;
        }

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the provided <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> for which to get the component of type <typeparamref name="T"/>.</param>
        /// <returns>A reference to the component of type <typeparamref name="T"/>.</returns>
        public ref T this[Entity entity]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _components[_mapping[entity.EntityId]];
        }
    }
}
