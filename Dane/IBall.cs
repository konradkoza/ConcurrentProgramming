﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBall
    {
        int  Id { get; }

        Vector2 Position { get; }
        Vector2 Velocity { get; set; }

        int Mass { get; }

        event EventHandler<BallChangedEventArgs> BallChanged;

        float X { get; }
        float Y { get; }

    
    }
}
