using System;
namespace DesignPatterns
{
    interface IEntityInSpace
    {
        string DescribeInteraction(IEntityInSpace other);
    }
}
