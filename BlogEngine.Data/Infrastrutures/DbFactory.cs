namespace BlogEngine.Data.Infrastrutures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BlogEngineDbContext blogEngineDbContext;

        public BlogEngineDbContext Init()
        {
            return blogEngineDbContext ?? (blogEngineDbContext = new BlogEngineDbContext());
        }

        protected override void DisposeCore()
        {
            if (blogEngineDbContext != null)
                blogEngineDbContext.Dispose();
        }
    }
}
