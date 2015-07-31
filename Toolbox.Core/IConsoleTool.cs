namespace Toolbox.Core
{
    public interface IConsoleTool
    {
        Categories Category { get; }

        string Name { get;  }

        string Description { get;  }

        void Run();


    }
}
