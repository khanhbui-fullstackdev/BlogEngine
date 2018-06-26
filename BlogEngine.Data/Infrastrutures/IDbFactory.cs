using System;

namespace BlogEngine.Data.Infrastrutures
{
    public interface IDbFactory : IDisposable
    {
        BlogEngineDbContext Init();
    }
}
