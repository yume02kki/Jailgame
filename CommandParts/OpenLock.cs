﻿using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class OpenLock:Open
{
    private bool isLocked;

    public OpenLock():base(false)
    {
        isLocked = true;
    }
    public void unlock()
    {
        this.isLocked = false;
    }
    public void execute()
    {
        if (!isLocked)
        {
            base.execute();
        }
    }
}