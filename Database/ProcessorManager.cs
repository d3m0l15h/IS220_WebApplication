using IS220_WebApplication.Context;

namespace IS220_WebApplication.Database;

public class ProcessorManager
{

    private UsersProcessor UsersProcessor{ get; set; }
    private GameProcessor GameProcessor { get; set; }
    private PublishersProcessor PublishersProcessor { get; set; }
    private GameCategoryProcessor GameCategoryProcessor { get; set; }
    private CategoriesProcessor CategoriesProcessor { get; set; }
    private GameOwnerProcessor GameOwnerProcessor{ get; set; }
    private DeveloperProcessor DeveloperProcessor{ get; set; }


    public ProcessorManager(MyDbContext db)
    {
        UsersProcessor = new UsersProcessor(db);
        GameProcessor = new GameProcessor(db);
        PublishersProcessor = new PublishersProcessor(db);
        GameCategoryProcessor = new GameCategoryProcessor(db);
        CategoriesProcessor = new CategoriesProcessor(db);
        GameOwnerProcessor = new GameOwnerProcessor(db);
        DeveloperProcessor = new DeveloperProcessor(db);
    }

    public void SetUserProcessor(UsersProcessor usersProcessor)
    {
        UsersProcessor = usersProcessor;
    }

    public UsersProcessor GetUsersProcessor()
    {
        return UsersProcessor;
    }

    public void SetCategoryProcessor(CategoriesProcessor categoriesProcessor)
    {
        CategoriesProcessor = categoriesProcessor;
    }

    public CategoriesProcessor GetCategoriesProcessor()
    {
        return CategoriesProcessor;
    }

    public void SetDeveloperProcessor(DeveloperProcessor developerProcessor)
    {
        DeveloperProcessor = developerProcessor;
    }

    public DeveloperProcessor GetDeveloperProcessor()
    {
        return DeveloperProcessor;
    }

    public void SetGameCategoryProcessor(GameCategoryProcessor gameCategoryProcessor)
    {
        GameCategoryProcessor = gameCategoryProcessor;
    }

    public GameCategoryProcessor GetGameCategoryProcessor()
    {
        return GameCategoryProcessor;
    }

    public void SetGameOwnedProcessor(GameOwnerProcessor gameOwnerProcessor)
    {
        GameOwnerProcessor = gameOwnerProcessor;
    }

    public GameOwnerProcessor GetGameOwnerProcessor()
    {
        return GameOwnerProcessor;
    }

    public void SetGameProcessor(GameProcessor gameProcessor)
    {
        GameProcessor = gameProcessor;
    }

    public GameProcessor GetGameProcessor()
    {
        return GameProcessor;
    }

    public void SetPublisherProcessor(PublishersProcessor publishersProcessor)
    {
        PublishersProcessor = publishersProcessor;
    }

    public PublishersProcessor GetPublishersProcessor()
    {
        return PublishersProcessor;
    }
}