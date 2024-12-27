using Zenject;

public class TypeFactory
{
    private readonly DiContainer _container;

    public TypeFactory(DiContainer container)
    {
        _container = container;
    }
    public Power Create(TypeName type)
    {
        return _container.ResolveId<Power>(type);
    }
}
