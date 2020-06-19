namespace HelloServiceNamespace
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in both code and config file together.
    public class HelloService : IHelloServiceChanged
    {
        public string GetMessageChanged(string name)
        {
            return $"hello {name}";
        }
    }
}
