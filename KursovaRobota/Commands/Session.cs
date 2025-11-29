using System;
using System.Collections.Generic;
using System.Text; 
using System.Linq;

namespace KursovaRobota;

public class Session
{
    public User CurrentUser { get; set; }
    public bool IsLoggedIn => CurrentUser != null;
}

