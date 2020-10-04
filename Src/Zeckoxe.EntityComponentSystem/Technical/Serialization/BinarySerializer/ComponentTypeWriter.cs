﻿using System;
using System.Collections.Generic;
using Zeckoxe.EntityComponentSystem.Serialization;

namespace Zeckoxe.EntityComponentSystem.Technical.Serialization.BinarySerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, ushort> _types;
        private readonly int _worldMaxCapacity;
        private readonly Predicate<Type> _componentFilter;

        private ushort _currentType;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(in StreamWriterWrapper writer, Dictionary<Type, ushort> types, int worldMaxCapacity, Predicate<Type> componentFilter)
        {
            _writer = writer;
            _types = types;
            _worldMaxCapacity = worldMaxCapacity;
            _componentFilter = componentFilter;
        }

        #endregion

        #region Methods

        public void WriteComponent<T>(int maxCapacity)
        {
            _types.Add(typeof(T), _currentType);

            _writer.WriteByte((byte)EntryType.ComponentType);
            _writer.Write(_currentType);
            _writer.WriteString(TypeNames.Get(typeof(T)));

            if (maxCapacity != _worldMaxCapacity)
            {
                _writer.WriteByte((byte)EntryType.ComponentMaxCapacity);
                _writer.Write(_currentType);
                _writer.Write(maxCapacity);
            }

            ++_currentType;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxCapacity)
        {
            if (_componentFilter(typeof(T)))
            {
                Action<ComponentTypeWriter, int> action = _writer.Context?.GetWorldWrite<T>();
                if (action is null)
                {
                    WriteComponent<T>(maxCapacity);
                }
                else
                {
                    action(this, maxCapacity);
                }
            }
        }

        #endregion
    }
}
