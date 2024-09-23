namespace NS.Core.Commons
{
    public class NotFoundException : Exception
    {
        public string Name { get; private set; }

        public NotFoundException(string name)
        {
            Name = name;
        }
        public override string Message => string.Format(Constants.ExceptionMessage.NOT_FOUND, Name);
    }
}
