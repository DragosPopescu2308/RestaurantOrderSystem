﻿namespace RestaurantOrderSystem.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
