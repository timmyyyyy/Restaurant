using MediatR;
using System;

namespace Restaurant.Common.FlowBuildingBlocks
{
    public interface IStronglyTypedNotification : INotification
    {
        public abstract Type Type { get; }
    }
}
