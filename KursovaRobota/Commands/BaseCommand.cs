using System;
using System.Collections.Generic;
using System.Text; 
using System.Linq;
namespace KursovaRobota;

public abstract class BaseCommand : ICommand
{
    protected readonly IShopService _service;
    protected readonly Session _session;

    public abstract string Name { get; }

    protected BaseCommand(IShopService service, Session session)
    {
        _service = service;
        _session = session;
    }

    public abstract void Execute();
}