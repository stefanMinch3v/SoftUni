namespace CollectionHierarchy.Interfaces
{
    /// <summary>
    /// this interface includes IAddable and IRemovable and also adds the Count property
    /// </summary>
    interface IMyList : IAddable, IRemovable
    {
        int Used { get; }   
    }
}
