namespace SistemaWeb.Shared.Exceptions
{
    public class DuplicateDataException : Exception
    {
        private const string _message = "Já existe este registro no banco de dados!";
        public DuplicateDataException(string message = _message) : base(message) { }

    }
}
