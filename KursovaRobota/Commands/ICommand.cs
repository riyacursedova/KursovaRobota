using System;
using System.Collections.Generic;
using System.Text; 
using System.Linq;
namespace KursovaRobota;

public interface ICommand
{
    string Name { get; }
    void Execute();
}