﻿namespace EFDecoupled.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
