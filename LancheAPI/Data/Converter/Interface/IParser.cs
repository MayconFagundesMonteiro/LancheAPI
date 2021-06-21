using System.Collections.Generic;

namespace LancheAPI.Data.Converter.Interface
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
