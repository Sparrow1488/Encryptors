using Encryptors.Abstractions;

namespace Encryptors.Examples.ClientServer
{
    /// Создаются на стороне клиента и сервера
    internal static class Shared
    {
        public readonly static Cryptographer Cryptographer = Cryptographer.New();
    }
}
