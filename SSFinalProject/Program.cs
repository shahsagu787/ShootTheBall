/*
 * Project : Shoot the ball
 * Purpose : To Submit Final Project
 * Revision History : Created by Sagar Shah on December 2021
 * 
 */
using System;

namespace ShootTheBall
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
