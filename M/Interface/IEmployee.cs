namespace M.Interface
{
    public interface IEmployee
    {
        string Name { get; }
        int Salary { get; }
        void Accept(IEmployeeVisitor visitor);
        void Add(Interface.IEmployee employee);
    }
}