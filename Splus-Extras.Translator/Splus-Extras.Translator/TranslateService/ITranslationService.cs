using System.Collections.Generic;
using System.Threading.Tasks;

namespace Splus_Extras.Translator
{
    public interface ITranslationService
    {
        Task<List<string>> Translate(List<string> listResources);
    }
}
