namespace M.Interface
{
    public interface IEmployeeVisitor
    {
        void Visit(Worker worker);
        void Visit(Manager manager);
        void Visit(Director director);
    }
}