namespace NS.Core.Commons.CustomException
{
    public class ExistException : Exception
    {
        public string Name { get; private set; }

        public ExistException(string name)
        {
            Name = name;
        }
        public override string Message => string.Format(Constants.ExceptionMessage.ALREADY_EXIST, Name);
    }
}
