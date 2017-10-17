using System.Collections.Generic;

namespace TAILS.Core.Providers
{
    public interface IFileReader<T>
    {
        List<T> ReadFile(string fileName);
    }
}