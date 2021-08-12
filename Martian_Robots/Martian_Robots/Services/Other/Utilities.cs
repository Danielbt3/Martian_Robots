using System;

namespace Martian_Robots.Services.Auxiliary
{
    public static class Utilities
    {
        public static (int, int) ParseCords(string X, string Y)
        {
            int mapX, mapY;

            bool parseSuccess = int.TryParse(X, out mapX);
            parseSuccess = int.TryParse(Y, out mapY) && parseSuccess;

            if (!parseSuccess)
                throw new Exception($"Error trying to parse  coordinates, please ensure that only entire numbers are used X: {X} Y: {Y}");
            if (mapX > 50 || mapY > 50)
                throw new Exception($"Coordinates bigger than 50 are not allowed");

            return (mapX, mapY);
        }
    }
}
